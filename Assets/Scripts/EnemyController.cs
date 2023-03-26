using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject deadVFX;
    public GameObject debuffVFX;

    int hp = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hp==0){
            Fire.score += 5;
            Instantiate(deadVFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet"){
            if (PowerUp.powerup)
            {
                Fire.score += 2;
                hp -= 2;
                PowerUp.powerup = false;
            }
            else
            {
                Fire.score += 1;
                hp -= 1;
            }
            Destroy(other.gameObject);
            if(hp!=0){
                Instantiate(debuffVFX, transform.position, transform.rotation);
            }
        }
    }
}
