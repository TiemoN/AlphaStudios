using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TankShooting2))]
public class TankMovement2 : MonoBehaviour
{
    [Header("Codes and Objects:")]
    [Header("ONLY PROGRAMMER!!!")]
    public TankShooting2 shootScript;
    public int m_PlayerNumber = 1;
    public GameObject TankTurret, TankBody, TankCanon;
    public Rigidbody rb;
    [Header("SFX and VFX:")]
    public AudioSource SpeedBoostSound;
    public GameObject speedEffect;
    public float destroyEffect = 5f;
    [Header("Tank Settings:")]
    [Header("GAME DESIGN")]
    [Range(1, 20)]
    public float tankSpeed = 10f;
    [Range(1, 30)]
    public float boostSpeed = 20f;
    [Range(1, 20)]
    public float tankRotationSpeed;
    [Range(1, 20)]
    public float turretTurnSpeed;
    [SerializeField] int powerUpCount = 3;

    [HideInInspector] public int powerup = -1;

    [HideInInspector] public Image uiPowerUpLogo1;
    [HideInInspector] public Image uiPowerUpLogo2;
    [HideInInspector] public Image uiPowerUpLogo3;
    [HideInInspector] public Image uiPowerUpLogo4;

    [HideInInspector] public Image uiSpeedBoostLogo1;
    [HideInInspector] public Image uiSpeedBoostLogo2;
    [HideInInspector] public Image uiSpeedBoostLogo3;
    [HideInInspector] public Image uiSpeedBoostLogo4;

    [HideInInspector] public Image uiPenShotLogo1;
    [HideInInspector] public Image uiPenShotLogo2;
    [HideInInspector] public Image uiPenShotLogo3;
    [HideInInspector] public Image uiPenShotLogo4;

    private void Awake()
    {
        uiPowerUpLogo1 = GameObject.Find("RapidFire IMAGE P1").GetComponent<Image>();
        uiPowerUpLogo2 = GameObject.Find("RapidFire IMAGE P2").GetComponent<Image>();
        uiPowerUpLogo3 = GameObject.Find("RapidFire IMAGE P3").GetComponent<Image>();
        uiPowerUpLogo4 = GameObject.Find("RapidFire IMAGE P4").GetComponent<Image>();

        uiSpeedBoostLogo1 = GameObject.Find("SpeedBoost IMAGE P1").GetComponent<Image>();
        uiSpeedBoostLogo2 = GameObject.Find("SpeedBoost IMAGE P2").GetComponent<Image>();
        uiSpeedBoostLogo3 = GameObject.Find("SpeedBoost IMAGE P3").GetComponent<Image>();
        uiSpeedBoostLogo4 = GameObject.Find("SpeedBoost IMAGE P4").GetComponent<Image>();

        uiPenShotLogo1 = GameObject.Find("PenShot IMAGE P1").GetComponent<Image>();
        uiPenShotLogo2 = GameObject.Find("PenShot IMAGE P2").GetComponent<Image>();
        uiPenShotLogo3 = GameObject.Find("PenShot IMAGE P3").GetComponent<Image>();
        uiPenShotLogo4 = GameObject.Find("PenShot IMAGE P4").GetComponent<Image>();
    }
    private void Start()
    {
        if (!shootScript)
        {
            shootScript = GetComponent<TankShooting2>();
        }

        uiPowerUpLogo1.gameObject.SetActive(false);
        uiPowerUpLogo2.gameObject.SetActive(false);
        uiPowerUpLogo3.gameObject.SetActive(false);
        uiPowerUpLogo4.gameObject.SetActive(false);

        uiSpeedBoostLogo1.gameObject.SetActive(false);
        uiSpeedBoostLogo2.gameObject.SetActive(false);
        uiSpeedBoostLogo3.gameObject.SetActive(false);
        uiSpeedBoostLogo4.gameObject.SetActive(false);

        uiPenShotLogo1.gameObject.SetActive(false);
        uiPenShotLogo2.gameObject.SetActive(false);
        uiPenShotLogo3.gameObject.SetActive(false);
        uiPenShotLogo4.gameObject.SetActive(false);
    }

    private void Update()
    {
        rb.velocity = Vector3.zero;

        Vector3 newPos = transform.position;
        newPos += new Vector3(0, 0, tankSpeed * 1) * Input.GetAxis("GPVertical" + m_PlayerNumber) * Time.deltaTime;
        newPos += new Vector3(tankSpeed * -1, 0, 0) * Input.GetAxis("GPHorizontal" + m_PlayerNumber) * Time.deltaTime;

        float turn = tankRotationSpeed * Time.deltaTime;
        if (newPos != transform.position)
        {
            Quaternion targetRotation = Quaternion.LookRotation(newPos - transform.position);
            TankBody.transform.rotation = Quaternion.Slerp(TankBody.transform.rotation, targetRotation, turn);
            transform.position = newPos;
        }

        if (Input.GetAxis("GPVerticalRight" + m_PlayerNumber) != 0 || Input.GetAxis("GPHorizontalRight" + m_PlayerNumber) != 0)
        {
            Vector3 ttnP = TankTurret.transform.position;
            ttnP += new Vector3(0, 0, tankSpeed * -1) * Input.GetAxis("GPVerticalRight" + m_PlayerNumber) * Time.deltaTime;
            ttnP += new Vector3(tankSpeed * 1, 0, 0) * Input.GetAxis("GPHorizontalRight" + m_PlayerNumber) * Time.deltaTime;
            float ttTurn = turretTurnSpeed * Time.deltaTime;

            Quaternion turretRotation = Quaternion.LookRotation(ttnP - TankTurret.transform.position);
            TankTurret.transform.rotation = Quaternion.Slerp(TankTurret.transform.rotation, turretRotation, ttTurn);
        }
        if (Input.GetAxis("GPLeftTrigger" + m_PlayerNumber) != 0)
        {
            switch (powerup)
            {
                //SpeedBoost
                case 0:
                    StartCoroutine("Speedboost");

                    if (m_PlayerNumber == 1)
                    {
                        uiSpeedBoostLogo1.gameObject.SetActive(false);
                    }
                    else if (m_PlayerNumber == 2)
                    {
                        uiSpeedBoostLogo2.gameObject.SetActive(false);
                    }
                    else if (m_PlayerNumber == 3)
                    {
                        uiSpeedBoostLogo3.gameObject.SetActive(false);
                    }
                    else
                    {
                        uiSpeedBoostLogo4.gameObject.SetActive(false);
                    }
                    break;
                //RapidFire
                case 1:
                    shootScript.StartCoroutine("Multishot");
                    if (m_PlayerNumber == 1)
                    {
                        uiPowerUpLogo1.gameObject.SetActive(false);
                    }
                    else if (m_PlayerNumber == 2)
                    {
                        uiPowerUpLogo2.gameObject.SetActive(false);
                    }
                    else if (m_PlayerNumber == 3)
                    {
                        uiPowerUpLogo3.gameObject.SetActive(false);
                    }
                    else
                    {
                        uiPowerUpLogo4.gameObject.SetActive(false);
                    }
                    break;
                //PenShot   
                case 2:
                    shootScript.FirePenetrationShot();

                    if (m_PlayerNumber == 1)
                    {
                        uiPenShotLogo1.gameObject.SetActive(false);
                    }
                    else if (m_PlayerNumber == 2)
                    {
                        uiPenShotLogo2.gameObject.SetActive(false);
                    }
                    else if (m_PlayerNumber == 3)
                    {
                        uiPenShotLogo3.gameObject.SetActive(false);
                    }
                    else
                    {
                        uiPenShotLogo4.gameObject.SetActive(false);
                    }
                    break;
            }
            powerup = -1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            if (powerup == -1)
            {
                Destroy(other.gameObject);
                powerup = Random.Range(0, powerUpCount);
                Debug.Log(powerup);
            }
            switch (powerup)
            {
                //SpeedBoost
                case 0:
                    if (m_PlayerNumber == 1)
                    {
                        uiSpeedBoostLogo1.gameObject.SetActive(true);
                    }
                    else if (m_PlayerNumber == 2)
                    {
                        uiSpeedBoostLogo2.gameObject.SetActive(true);
                    }
                    else if (m_PlayerNumber == 3)
                    {
                        uiSpeedBoostLogo3.gameObject.SetActive(true);
                    }
                    else
                    {
                        uiSpeedBoostLogo4.gameObject.SetActive(true);
                    }
                    break;
                //RapidFire
                case 1:
                    if (m_PlayerNumber == 1)
                    {
                        uiPowerUpLogo1.gameObject.SetActive(true);
                    }
                    else if (m_PlayerNumber == 2)
                    {
                        uiPowerUpLogo2.gameObject.SetActive(true);
                    }
                    else if (m_PlayerNumber == 3)
                    {
                        uiPowerUpLogo3.gameObject.SetActive(true);
                    }
                    else
                    {
                        uiPowerUpLogo4.gameObject.SetActive(true);
                    }
                    break;
                //PenShot   
                case 2:
                    if (m_PlayerNumber == 1)
                    {
                        uiPenShotLogo1.gameObject.SetActive(true);
                    }
                    else if (m_PlayerNumber == 2)
                    {
                        uiPenShotLogo2.gameObject.SetActive(true);
                    }
                    else if (m_PlayerNumber == 3)
                    {
                        uiPenShotLogo3.gameObject.SetActive(true);
                    }
                    else
                    {
                        uiPenShotLogo4.gameObject.SetActive(true);
                    }
                    break;
            }
        }
    }

    IEnumerator Speedboost()
    {
        SpeedBoostSound.Play();
        GameObject speedSFX = Instantiate(speedEffect, transform);
        Destroy(speedSFX, destroyEffect);
        tankSpeed = boostSpeed;
        yield return new WaitForSeconds(3);
        tankSpeed = 10f;
    }
}


