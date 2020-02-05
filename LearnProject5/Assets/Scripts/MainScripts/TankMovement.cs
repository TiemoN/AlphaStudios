using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TankMovement : MonoBehaviour
{
    public int m_PlayerNumber = 1;
    public GameObject TankTurret, TankBody, Canon, Bombe, Mine;
    public float speed;
    public float rotspeed;
    public float trotspeed;
    public TankShooting shootScript;

    public Image popUpImage1;
    public Image popUpImage2;
    public Image popUpImage3;
    public Image popUpImage4;


    int powerup = -1;

    public Rigidbody rb;

    private void Update()
    {
        rb.velocity = Vector3.zero;

        Vector3 newPos = transform.position;
        newPos += new Vector3(0, 0, speed * 1) * Input.GetAxis("GPVertical" + m_PlayerNumber) * Time.deltaTime;
        newPos += new Vector3(speed * -1, 0, 0) * Input.GetAxis("GPHorizontal" + m_PlayerNumber) * Time.deltaTime;

        float turn = trotspeed * Time.deltaTime;
        if (newPos != transform.position)
        {
            Quaternion targetRotation = Quaternion.LookRotation(newPos - transform.position);
            TankBody.transform.rotation = Quaternion.Slerp(TankBody.transform.rotation, targetRotation, turn);
            transform.position = newPos;
        }

        if (Input.GetAxis("GPVerticalRight" + m_PlayerNumber) != 0 || Input.GetAxis("GPHorizontalRight" + m_PlayerNumber) != 0)
        {
            Vector3 ttnP = TankTurret.transform.position;
            ttnP += new Vector3(0, 0, speed * -1) * Input.GetAxis("GPVerticalRight" + m_PlayerNumber) * Time.deltaTime;
            ttnP += new Vector3(speed * 1, 0, 0) * Input.GetAxis("GPHorizontalRight" + m_PlayerNumber) * Time.deltaTime;
            float ttTurn = rotspeed * Time.deltaTime;

            Quaternion turretRotation = Quaternion.LookRotation(ttnP - TankTurret.transform.position);
            TankTurret.transform.rotation = Quaternion.Slerp(TankTurret.transform.rotation, turretRotation, ttTurn);
        }
        if (Input.GetAxis("GPLeftTrigger" + m_PlayerNumber) != 0)
        {
            switch (powerup)
            {
                //speed
                case 0:
                    StartCoroutine("Speedboost");
                    break;
                //live
                case 1:
                    GetComponent<TankShooting>().StartCoroutine("Multishot");
                    break;
                //Mortar    
                /*case 2:
                    Mine.transform.position = transform.position;
                    Mine.transform.rotation = transform.rotation;
                    GameObject NewMine = Instantiate(Mine);
                    break;*/
            }
            powerup = -1;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            if (powerup == -1)
            {
                powerup = Random.Range(0, 2);
                Debug.Log(powerup);
            }
            if (m_PlayerNumber == 1)
            {
                popUpImage1.gameObject.SetActive(true);
            }
            else if(m_PlayerNumber == 2)
            {
                popUpImage2.gameObject.SetActive(true);
            }
            else if (m_PlayerNumber == 3)
            {
                popUpImage3.gameObject.SetActive(true);
            }
            else
            {
                popUpImage4.gameObject.SetActive(true);
            }
        }
    }

    IEnumerator Speedboost()
    {
        speed = speed * 2;
        yield return new WaitForSeconds(5);
        speed = speed / 2;

    }

   
}





