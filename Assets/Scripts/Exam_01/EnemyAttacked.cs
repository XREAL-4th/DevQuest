using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacked : MonoBehaviour
{
    public GameObject Life1, Life2;

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log(other.gameObject.name);

        if(other.gameObject.name.Contains("VFX_Tutorial"))
        {
            Debug.Log("맞음");
            if(Life2.activeSelf == true)
            {
                Life2.SetActive(false);          
                Debug.Log("한번 맞음");
            } else if(Life1.activeSelf == true)
            {
                Life1.SetActive(false);
                Debug.Log("두번 맞음");
            } else
            {
                gameObject.SetActive(false);
                Debug.Log("세번 맞음");
            }
        }
        
    }
}
