using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Status")]
    [SerializeField] private int dmg;
    [SerializeField] public float coolDown;
    [SerializeField] private float spead;
    [SerializeField] private float duration;
    [SerializeField] private ParticleSystem enemyHitParticle;
    [SerializeField] private ParticleSystem enemyHeadParticle;
    [SerializeField] private ParticleSystem stoneParticle;

    [HideInInspector] public bool isPowerShot = false;
    public Vector3 dir;
    private bool fire = false;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, duration);
    }

    // Update is called once per frame
    void Update()
    {
        if(fire)
        {
            transform.position += dir * spead * Time.deltaTime;
        }
    }

    public void SetDirection(Vector3 v)
    {
        dir = v;
        fire = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        ParticleSystem instance;

        if (other.tag == "Enemy")
        {
            if(other.name == "Head")
            {
                if(isPowerShot)
                {
                    other.GetComponentInParent<Enemy>().TakeDamage(dmg * 4, transform);
                    instance = Instantiate(enemyHeadParticle, transform.position, Quaternion.identity);
                }
                else
                {
                    other.GetComponentInParent<Enemy>().TakeDamage(dmg * 2, transform);
                    instance = Instantiate(enemyHeadParticle, transform.position, Quaternion.identity);
                }
            }
            else
            {
                if (isPowerShot)
                {
                    other.GetComponentInParent<Enemy>().TakeDamage(dmg*2, transform);
                    instance = Instantiate(enemyHitParticle, transform.position, Quaternion.identity);
                }
                else
                {
                    other.GetComponentInParent<Enemy>().TakeDamage(dmg, transform);
                    instance = Instantiate(enemyHitParticle, transform.position, Quaternion.identity);
                }
            }
        }
        else
        {
            instance = Instantiate(stoneParticle, transform.position, Quaternion.identity);
        }
        instance.Play();
        Destroy(instance.gameObject, instance.main.duration);
        Destroy(gameObject);
    }

}
