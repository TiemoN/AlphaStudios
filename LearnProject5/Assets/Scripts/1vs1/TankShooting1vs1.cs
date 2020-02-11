using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TankShooting1vs1 : MonoBehaviour
{
    [Header("Objects:")]
    [Header("ONLY PROGRAMMER!!!")]
    public int m_PlayerNumber = 1;
    [SerializeField] GameObject Shell;
    [SerializeField] GameObject penetrationShell;
    public Transform m_FireTransform;
    [Header("VFX:")]
    public ParticleSystem m_ShootParticle;
    [Header("Shell Shoot Settings:")]
    [Header("GAME DESIGN")]
    [Range(1, 50)]
    public float projectileSpeed = 30f;
    [Range(1, 5)]
    public float setShootCooldown = 2f;
    [Range(0, 1)]
    public float rapidfireShoot1Cooldown = 0.1f;
    [Range(0, 1)]
    public float rapidfireShoot2Cooldown = 0.2f;
    [Range(0, 1)]
    public float rapidfireShoot3Cooldown = 0.3f;
    //public float rapidfireShoot4Cooldown = 0.1f;
    private float cooldown;

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
                cooldown = setShootCooldown;
            }
        }
    }

    public IEnumerator Multishot()
    {
        Fire();
        m_ShootParticle = Instantiate(m_ShootParticle, m_FireTransform.position, m_FireTransform.rotation);
        yield return new WaitForSeconds(rapidfireShoot1Cooldown);
        Fire();
        yield return new WaitForSeconds(rapidfireShoot2Cooldown);
        Fire();
        yield return new WaitForSeconds(rapidfireShoot3Cooldown);
        //Fire();
        //yield return new WaitForSeconds(0.4f);
    }

    private void Fire()
    {
        GameObject shootShell = Instantiate(Shell, m_FireTransform.position, m_FireTransform.rotation);

        shootShell.GetComponent<Rigidbody>().velocity = projectileSpeed * m_FireTransform.forward;
    }

    public void FirePenetrationShot()
    {
        GameObject shootShell = Instantiate(penetrationShell, m_FireTransform.position, m_FireTransform.rotation);

        m_ShootParticle = Instantiate(m_ShootParticle, m_FireTransform.position, m_FireTransform.rotation);

        shootShell.GetComponent<Rigidbody>().velocity = projectileSpeed * m_FireTransform.forward;
    }
}
