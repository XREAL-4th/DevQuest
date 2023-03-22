using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Status")]
    [SerializeField] private int dmg;
    [SerializeField] private float spead;
    [SerializeField] private float duration;
    [SerializeField] private ParticleSystem enemyParticle;
    [SerializeField] private ParticleSystem stoneParticle;

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
            other.GetComponent<Enemy>().TakeDamage(dmg);
            instance = Instantiate(enemyParticle, transform.position, Quaternion.identity);
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
