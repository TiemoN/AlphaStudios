using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank3 : MonoBehaviour
{
    public GameObject Tanktop, Canon, Bombe, Mine;
    public float speed;
    public float rotspeed;
    public bool advancedControl;
    float winkel, winkel2;
    int powerup = -1;
    public Rigidbody rb;
    
    void Update()
    {

        rb.velocity = Vector3.zero;

        if (advancedControl)
        {
            transform.Translate(Vector3.forward * speed * Input.GetAxis("P3Vertical") * Time.deltaTime);
            transform.Rotate(Vector3.down * rotspeed * Input.GetAxis("P3Horizontal") * Time.deltaTime);
            Tanktop.transform.Rotate(Vector3.up * rotspeed * Input.GetAxis("P3HorizontalRight") * Time.deltaTime);
        }
        else
        {
            if (Input.GetAxis("P3Vertical") != 0 || Input.GetAxis("P3Horizontal") != 0)
            {
                winkel = Mathf.Atan2(Input.GetAxis("P3Horizontal"), Input.GetAxis("P3Vertical")) * Mathf.Rad2Deg;
                if (winkel < 0)
                {
                    winkel = winkel + 360;
                }
                winkel = 360 - winkel;

                if (winkel != this.transform.eulerAngles.y && !(winkel - 10 < this.transform.eulerAngles.y && winkel > this.transform.eulerAngles.y) && !(winkel + 10 > this.transform.eulerAngles.y && winkel < this.transform.eulerAngles.y))
                {
                    if ((this.transform.eulerAngles.y - winkel < 0 || this.transform.eulerAngles.y - winkel > 180) && this.transform.eulerAngles.y - winkel > -180)
                    {
                        transform.Rotate(Vector3.down * -rotspeed * Time.deltaTime);
                    }
                    else
                    {
                        transform.Rotate(Vector3.down * rotspeed * Time.deltaTime);
                    }
                }
                else
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * speed);
                }
            }



            if (Input.GetAxis("P3VerticalRight") != 0 || Input.GetAxis("P3HorizontalRight") != 0)
            {
                winkel2 = Mathf.Atan2(Input.GetAxis("P3VerticalRight"), Input.GetAxis("P3HorizontalRight")) * Mathf.Rad2Deg;

                winkel2 = winkel2 + 90;

                if (winkel2 < 0)
                {
                    winkel2 = winkel2 + 360;
                }

                if (winkel2 != Tanktop.transform.eulerAngles.y && !(winkel2 - 10 < Tanktop.transform.eulerAngles.y && winkel2 > Tanktop.transform.eulerAngles.y) && !(winkel2 + 10 > Tanktop.transform.eulerAngles.y && winkel2 < Tanktop.transform.eulerAngles.y))
                {
                    if ((Tanktop.transform.eulerAngles.y - winkel2 < 0 || Tanktop.transform.eulerAngles.y - winkel2 > 180) && Tanktop.transform.eulerAngles.y - winkel2 > -180)
                    {
                        Tanktop.transform.Rotate(Vector3.down * -rotspeed * Time.deltaTime);
                    }
                    else
                    {
                        Tanktop.transform.Rotate(Vector3.down * rotspeed * Time.deltaTime);
                    }
                }
            }
        }


        if (Input.GetAxis("P3LeftTrigger") != 0)
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
                    Bombe.transform.position = Vector3.up + Vector3.right + Vector3.back;
                    Bombe.SetActive(true);
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
