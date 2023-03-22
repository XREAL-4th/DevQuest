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
            Debug.Log("����");
            if(Life2.activeSelf == true)
            {
                Life2.SetActive(false);          
                Debug.Log("�ѹ� ����");
            } else if(Life1.activeSelf == true)
            {
                Life1.SetActive(false);
                Debug.Log("�ι� ����");
            } else
            {
                gameObject.SetActive(false);
                Debug.Log("���� ����");
            }
        }
        
    }
}
