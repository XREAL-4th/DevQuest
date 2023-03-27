using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
        if(other.tag == "Player")
        {
            Score.coinAmount +=1; 
            Destroy(this.gameObject); //코인 흭득시 코인 오브젝트 삭제
           
        }
   }
}
