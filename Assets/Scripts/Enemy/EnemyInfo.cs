using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public int enemyHealth = 5;
    public ParticleSystem particleSystem;
    
    // 체력 0이 되면 터지고 비활성화해야함.
    public void DescreaseHealth()
    {
        enemyHealth -= 1;
        Debug.Log($"hp : {enemyHealth}");
        if (enemyHealth <= 0)
        {
            
            // particleSystem.Play();
        }        
    }
    
    
}
