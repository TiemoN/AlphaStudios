using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TankShooting1vs1H))]
public class TankMovement1vs1H : MonoBehaviour
{
    [Header("Codes and Objects:")]
    [Header("ONLY PROGRAMMER!!!")]
    public TankShooting1vs1H shootScript;
    public int m_PlayerNumber = 1;
    public GameObject TankTurret, TankBody, TankCanon;
    public Rigidbody rb;
    [Header("SFX:")]
    public AudioSource SpeedBoostSound;
    //public AudioSource MovementSound;
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

    int powerup = -1;

    private Image uiPowerUpLogo1;
    private Image uiPowerUpLogo2;

    private Image uiSpeedBoostLogo1;
    private Image uiSpeedBoostLogo2;

    private Image uiPenShotLogo1;
    private Image uiPenShotLogo2;
   
    private void Awake()
    {
        uiPowerUpLogo1 = GameObject.Find("RapidFire IMAGE P1").GetComponent<Image>();
        uiPowerUpLogo2 = GameObject.Find("RapidFire IMAGE P2").GetComponent<Image>();
       
        uiSpeedBoostLogo1 = GameObject.Find("SpeedBoost IMAGE P1").GetComponent<Image>();
        uiSpeedBoostLogo2 = GameObject.Find("SpeedBoost IMAGE P2").GetComponent<Image>();
       

        uiPenShotLogo1 = GameObject.Find("PenShot IMAGE P1").GetComponent<Image>();
        uiPenShotLogo2 = GameObject.Find("PenShot IMAGE P2").GetComponent<Image>();
       
    }
    private void Start()
    {
        if (!shootScript)
        {
            shootScript = GetComponent<TankShooting1vs1H>();
        }

        uiPowerUpLogo1.gameObject.SetActive(false);
        uiPowerUpLogo2.gameObject.SetActive(false);
       

        uiSpeedBoostLogo1.gameObject.SetActive(false);
        uiSpeedBoostLogo2.gameObject.SetActive(false);
      

        uiPenShotLogo1.gameObject.SetActive(false);
        uiPenShotLogo2.gameObject.SetActive(false);
        
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

            //if (MovementSound.isPlaying == false)
            //MovementSound.Play();
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
                       
                    }
                    else
                    {
                        
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
                        
                    }
                    else
                    {
                        
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
                        
                    }
                    else
                    {
                        
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
                        
                    }
                    else
                    {
                        
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
                        
                    }
                    else
                    {
                       
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
                        
                    }
                    else
                    {
                       
                    }
                    break;
            }
        }
    }

    IEnumerator Speedboost()
    {
        SpeedBoostSound.Play();

        tankSpeed = boostSpeed;
        yield return new WaitForSeconds(3);
        tankSpeed = 10f;
    }
}







