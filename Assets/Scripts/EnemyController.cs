using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    int hp = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hp==0){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        hp-=1; 
        Destroy(other.gameObject);
    }
}
