using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    public int m_PlayerNumber = 1;              // Used to identify the different players.
    public GameObject Shell;
    public Rigidbody m_Shell;                   // Prefab of the shell.
    public Transform m_FireTransform;
    float cooldown;
    public float setcooldown;
    public ParticleSystem ShootParticle;

    private string m_FireButton;                // The input axis that is used for launching shells.
    private bool m_Fired;                       // Whether or not the shell has been launched with this button press.


    private void Start()
    {
        // The fire axis is based on the player number.
        //m_FireButton = "GPRighTrigger" + m_PlayerNumber;

        cooldown = cooldown - Time.deltaTime;
        if (Input.GetAxis("P1RightTrigger" + m_PlayerNumber) > 0)
        {
            if (cooldown <= 0)
            {
                shoot();
            }
        }
    }

    private void shoot()
    {
        Shell.transform.position = transform.position;
        Shell.transform.rotation = transform.rotation;
        GameObject NewCanonBall = Instantiate(Shell);
        cooldown = setcooldown;
        Instantiate(ShootParticle, transform.position, transform.rotation);
    }
}
