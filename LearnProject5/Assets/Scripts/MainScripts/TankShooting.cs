using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    public int m_PlayerNumber = 1;
    [SerializeField] GameObject Shell;
    [SerializeField] GameObject penetrationShell;
    public Transform m_FireTransform;
    public ParticleSystem m_ShootParticle;
    private float m_CurrentLaunchForce = 30f;
    float cooldown;



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
                m_ShootParticle = Instantiate(m_ShootParticle, m_FireTransform.position, m_FireTransform.rotation);
                cooldown = 2f;
            }
        }
    }

    public IEnumerator Multishot()
    {
        Fire();
        m_ShootParticle = Instantiate(m_ShootParticle, m_FireTransform.position, m_FireTransform.rotation);
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
        m_ShootParticle = Instantiate(m_ShootParticle, m_FireTransform.position, m_FireTransform.rotation);
        shootShell.GetComponent<Rigidbody>().velocity = m_CurrentLaunchForce * m_FireTransform.forward;
    }

}