using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RedBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            // 충돌한 것이 redball 이면 enemyScore 증가, 
            GameManager.instance.enemyScore += 1;
            gameObject.SetActive(false);
        }
        else if (other.gameObject.layer == 6) // layer 9 => fevertime
        {
            GameManager.instance.moveSpeed *= 1.5f;
            GameManager.instance.playerScore += 1;
            gameObject.SetActive(false);
        }
        
    }
}
