using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank1 : MonoBehaviour
{
    public GameObject Tanktop, Canon, Bombe, Mine, Body;
    public float speed;
    public float rotspeed;
    public float Trotspeed;
    public enum ControlMode {
            Mode1,
            Talib,
            Viktor,
    }
    public ControlMode mode;
    float winkel, winkel2;
    int powerup = -1;
    public Rigidbody rb;

    void Update()
    {

        rb.velocity = Vector3.zero;

        if (mode == ControlMode.Mode1)
        {
            transform.Translate(Vector3.forward * speed * Input.GetAxis("P1Vertical") * Time.deltaTime);
            transform.Rotate(Vector3.down * rotspeed * Input.GetAxis("P1Horizontal") * Time.deltaTime);
            Tanktop.transform.Rotate(Vector3.up * rotspeed * Input.GetAxis("P1HorizontalRight") * Time.deltaTime);
        }
        else if (mode == ControlMode.Talib)
        {
            this.transform.position += new Vector3(0, 0, speed * 1) * Input.GetAxis("P1Vertical") * Time.deltaTime;
            this.transform.position += new Vector3(speed * 1, 0, 0) * Input.GetAxis("P1Horizontal") * Time.deltaTime;

            transform.Rotate(Vector3.down * rotspeed * Input.GetAxis("P1Horizontal") * Time.deltaTime);
            Tanktop.transform.Rotate(Vector3.up * rotspeed * Input.GetAxis("P1HorizontalRight") * Time.deltaTime);
        }
        else if(mode == ControlMode.Viktor) {
            
            Vector3 newPos = transform.position;
            newPos += new Vector3(0, 0, speed * 1) * Input.GetAxis("P1Vertical") * Time.deltaTime;
            newPos += new Vector3(speed * -1, 0, 0) * Input.GetAxis("P1Horizontal") * Time.deltaTime;

            float turn = Trotspeed * Time.deltaTime;
            if (newPos != transform.position)
            {
                Quaternion targetRotation = Quaternion.LookRotation(newPos - transform.position);
                Body.transform.rotation = Quaternion.Slerp(Body.transform.rotation, targetRotation, turn);
                transform.position = newPos;
            }

            if (Input.GetAxis("P1VerticalRight") != 0 || Input.GetAxis("P1HorizontalRight") != 0)
            {
                Vector3 ttnP = Tanktop.transform.position;
                ttnP += new Vector3(0, 0, speed * -1) * Input.GetAxis("P1VerticalRight") * Time.deltaTime;
                ttnP += new Vector3(speed * 1, 0, 0) * Input.GetAxis("P1HorizontalRight") * Time.deltaTime;
                float ttTurn = rotspeed * Time.deltaTime;

                Quaternion turretRotation = Quaternion.LookRotation(ttnP - Tanktop.transform.position);
                Tanktop.transform.rotation = Quaternion.Slerp(Tanktop.transform.rotation, turretRotation, ttTurn);
            }
        }


        if (Input.GetAxis("P1LeftTrigger") != 0)
        {
            switch (powerup)
            {
                //speed
                case 0:
                    StartCoroutine("Speedboost");
                    break;
                //live
                case 1:
                    this.gameObject.SendMessage("Live");
                    break;
                    //5 schüsse schnell hintereinander
                case 2:
                    Canon.SendMessage("Multishot");
                    break;
                case 3:
                    //bombe
                    //Bombe.transform.position = Vector3.up + Vector3.right + Vector3.back;
                    //Bombe.SetActive(true);
                    break;
                    //Mine
                case 4:
                    Mine.transform.position = transform.position;
                    Mine.transform.rotation = transform.rotation;
                    GameObject NewMine = Instantiate(Mine);
                    break;
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
                powerup = Random.Range(0, 5);
                Debug.Log(powerup);
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
