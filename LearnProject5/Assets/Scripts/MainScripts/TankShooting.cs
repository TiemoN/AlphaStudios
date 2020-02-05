using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    public int m_PlayerNumber = 1;
    public GameObject Shell;
    [SerializeField] GameObject penetrationShell;
    public float setcooldown;
    float cooldown;
    public ParticleSystem ShootParticle;
    public Transform m_FireTransform;
    private float m_CurrentLaunchForce = 30f;



    private bool m_Fired;

    private void Start()
    {
        if (!penetrationShell)
        {
            Debug.LogError("penetration shell prefab not set.");
            Destroy(this);
            return;
        }
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;
        if (Input.GetAxis("GPRightTrigger" + m_PlayerNumber) > 0)
        {

            if (cooldown <= 0)
            {
                Fire();
                cooldown = 2f;
            }
        }
    }

    public IEnumerator Multishot()
    {
        Fire();
        yield return new WaitForSeconds(0.1f);
        Fire();
        yield return new WaitForSeconds(0.2f);
        Fire();
        yield return new WaitForSeconds(0.3f);
        Fire();
        yield return new WaitForSeconds(0.4f);
        Fire();
    }

    private void Fire()
    {
        GameObject shootShell = Instantiate(Shell, m_FireTransform.position, m_FireTransform.rotation);

        shootShell.GetComponent<Rigidbody>().velocity = m_CurrentLaunchForce * m_FireTransform.forward;
    }

    public void FirePenetrationShot()
    {
        GameObject shootShell = Instantiate(penetrationShell, m_FireTransform.position, m_FireTransform.rotation);

        shootShell.GetComponent<Rigidbody>().velocity = m_CurrentLaunchForce * m_FireTransform.forward;
    }

}