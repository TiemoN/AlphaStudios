using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public int playerNumber = 4;

    public GameObject TankTurret, TankBody, canonball, Canon, Bombe, Mine;
    public float lives;
    public float speed;
    public float rotspeed;
    public float trotspeed;
    public float setcooldown;
    float cooldown;

    int powerup = -1;

    public Rigidbody rb;

    private void Update()
    {
        rb.velocity = Vector3.zero;

        Vector3 newPos = transform.position;
        newPos += new Vector3(0, 0, speed * 1) * Input.GetAxis("GPVertical") * Time.deltaTime;
        newPos += new Vector3(speed * -1, 0, 0) * Input.GetAxis("GPHorizontal") * Time.deltaTime;

        float turn = trotspeed * Time.deltaTime;
        if (newPos != transform.position)
        {
            Quaternion targetRotation = Quaternion.LookRotation(newPos - transform.position);
            TankBody.transform.rotation = Quaternion.Slerp(TankBody.transform.rotation, targetRotation, turn);
            transform.position = newPos;
        }

        if (Input.GetAxis("GPVerticalRight") != 0 || Input.GetAxis("GPHorizontalRight") != 0)
        {
            Vector3 ttnP = TankTurret.transform.position;
            ttnP += new Vector3(0, 0, speed * -1) * Input.GetAxis("GPVerticalRight") * Time.deltaTime;
            ttnP += new Vector3(speed * 1, 0, 0) * Input.GetAxis("GPHorizontalRight") * Time.deltaTime;
            float ttTurn = rotspeed * Time.deltaTime;

            Quaternion turretRotation = Quaternion.LookRotation(ttnP - TankTurret.transform.position);
            TankTurret.transform.rotation = Quaternion.Slerp(TankTurret.transform.rotation, turretRotation, ttTurn);
        }
    }
}
/*cooldown = cooldown - Time.deltaTime;
if (Input.GetAxis("GPRightTrigger") > 0)
{
    if (cooldown <= 0)
    {
        shoot();
    }
}
IEnumerator Multishot()
{
    shoot();
    yield return new WaitForSeconds(0.1f);
    shoot();
    yield return new WaitForSeconds(0.1f);
    shoot();
    yield return new WaitForSeconds(0.1f);
    shoot();
    yield return new WaitForSeconds(0.1f);
    shoot();
}
if (Input.GetAxis("GPLeftTrigger") != 0)
{
    switch (powerup)
    {
        case 0:
            StartCoroutine("Speedboost");
            break;
        case 1:
            Canon.SendMessage("Multishot");
            break;
        case 2:
            Bombe.transform.position = Vector3.up + Vector3.right + Vector3.back;
            Bombe.SetActive(true);
            break;
        case 3:
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
if (other.gameObject.CompareTag("Item")) //bei erstellen von Powerups nicht vergessen ein Tag zu machen
{
    Destroy(other.gameObject);
    if (powerup == -1)
    {
        powerup = Random.Range(0, 5);
        Debug.Log(powerup);
    }
}
if (other.gameObject.CompareTag("canonball") || other.gameObject.CompareTag("Explosion"))
{
    lives--;
    if (lives <= 0)
    {
        Destroy(this.gameObject);
    }
}
}
void shoot()
{
canonball.transform.position = transform.position;
canonball.transform.rotation = transform.rotation;
GameObject NewCanonBall = Instantiate(canonball);
cooldown = setcooldown;
}

}*/
