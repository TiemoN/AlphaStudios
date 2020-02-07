using UnityEngine;

public class ShellExplosion : MonoBehaviour
{
    [Header("Objects:")]
    [Header("ONLY PROGRAMMER!!!")]
    public LayerMask m_TankMask;
    public Rigidbody rb;
    [Header("VFX and SFX:")]
    public ParticleSystem m_BounceParticles;                     
    public AudioSource m_BounceAudio;
    //public AudioSource m_BounceDestroyAudio;
    [Header("Shell Damage Settings:")]
    [Header("WARNING: Dont touch in OneHitKill Mode. Let Damage on 100!!!")]
    [Range(0,100)]
    public float shellDamage = 100f;                   
    private float m_ExplosionForce = 1000f;              
    private float m_MaxLifeTime = 20f;                    
    private float m_ExplosionRadius = 3f;                
    private int speed; //Check warum es diese Varibale gibt bei void Start.
    bool bounce;

    private void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
        bounce = false;
        rb.AddRelativeForce(Vector3.forward * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Players")
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_TankMask);

            for (int i = 0; i < colliders.Length; i++)
            {
                Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

                if (!targetRigidbody)
                    continue;

                targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);

                TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();

                if (!targetHealth)
                    continue;

                float damage = CalculateDamage(targetRigidbody.position);

                targetHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        m_BounceAudio.Play();
        
        if (bounce)
        {
            m_BounceParticles = Instantiate(m_BounceParticles, transform.position, Quaternion.Euler(-90f, 0f, 0f));
            
            Destroy(this.gameObject);
        }            
        bounce = true;
    }

    private float CalculateDamage(Vector3 targetPosition)
    {
        Vector3 explosionToTarget = targetPosition - transform.position;

        float explosionDistance = explosionToTarget.magnitude;

        float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;

        float damage = relativeDistance * shellDamage;

        damage = Mathf.Max(0f, damage);

        return damage;
    }
}