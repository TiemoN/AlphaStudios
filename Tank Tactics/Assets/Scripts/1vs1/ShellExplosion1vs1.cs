using UnityEngine;

public class ShellExplosion1vs1 : MonoBehaviour
{
    [Header("Objects:")]
    [Header("ONLY PROGRAMMER!!!")]
    public LayerMask m_TankMask;
    public Rigidbody rb;
    [Header("VFX and SFX:")]
    public ParticleSystem m_BounceParticles;
    public AudioSource m_BounceAudio;
    public AudioClip m_ShootAudio;
    public AudioClip m_BounceDestroyAudio;
    [Header("Shell Damage Settings:")]
    [Header("WARNING: Dont touch in OneHitKill Mode. Let Damage on 100!!!")]
    [Range(0, 100)]
    public float shellDamage = 100f;
    private float m_ExplosionForce = 1000f;
    private float m_MaxLifeTime = 10f;
    private float m_ExplosionRadius = 9f;
    private int speed; //Check warum es diese Varibale gibt bei void Start.
    bool bounce;
    private int timesBounced;
    public int bounceQuantity = 2;

    private void Start()
    {
        SceneAudioPlayer.Play(m_ShootAudio);

        Destroy(gameObject, m_MaxLifeTime);
        bounce = false;
        timesBounced = 0;
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

                TankHealth1vs1 targetHealth = targetRigidbody.GetComponent<TankHealth1vs1>();

                if (!targetHealth)
                    continue;

                float damage = CalculateDamage(targetRigidbody.position);

                targetHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
            m_BounceParticles = Instantiate(m_BounceParticles, transform.position, Quaternion.Euler(-90f, 0f, 0f));
            SceneAudioPlayer.Play(m_BounceDestroyAudio);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        m_BounceAudio.Play();
        timesBounced++;

        if (bounce)
        {
            m_BounceParticles = Instantiate(m_BounceParticles, transform.position, Quaternion.Euler(-90f, 0f, 0f));

            if (timesBounced >= bounceQuantity)
            {
                Destroy(this.gameObject);
                SceneAudioPlayer.Play(m_BounceDestroyAudio);
            }
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