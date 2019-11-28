using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank1 : MonoBehaviour
{
    public GameObject Tanktop, Canon;
    public float speed;
    public float rotspeed;
    public bool advancedControl;
    float winkel;
    int powerup = -1;

    void Update()
    {
        if (advancedControl)
        {
            transform.Translate(Vector3.forward * speed * Input.GetAxis("P1Vertical") * Time.deltaTime);
            transform.Rotate(Vector3.down * rotspeed * Input.GetAxis("P1Horizontal") * Time.deltaTime);
            Tanktop.transform.Rotate(Vector3.back * rotspeed * Input.GetAxis("P1HorizontalRight") * Time.deltaTime);
        }
        else
        {
            if(Input.GetAxis("P1Vertical") != 0 || Input.GetAxis("P1Horizontal") != 0)
            {
                winkel = Mathf.Atan2(Input.GetAxis("P1Horizontal"), Input.GetAxis("P1Vertical")) * Mathf.Rad2Deg;
                if(winkel < 0)
                {
                    winkel = winkel + 360;
                }
                winkel = 360 - winkel;
                if(winkel != this.transform.eulerAngles.y && !(winkel -10 < this.transform.eulerAngles.y && winkel > this.transform.eulerAngles.y) && !(winkel +10 > this.transform.eulerAngles.y && winkel < this.transform.eulerAngles.y))
                {
                    if(this.transform.eulerAngles.y - winkel -1 < 0)
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
                case 2:
                    Canon.SendMessage("Multishot");
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
                powerup = Random.Range(0, 3);
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
