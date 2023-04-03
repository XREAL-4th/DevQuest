using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemtHPUICtrl : MonoBehaviour
{
    //public List<Transform> obj;
    //public List<GameObject> hp_bar;

    //public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        /*
        camera = Camera.main;
        for(int i=0; i< obj.Count; i++)
        {
            hp_bar[i].transform.position = obj[i].position;

        }
        */

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(Camera.main.transform.position); //HP바가 플레이어(카메라)를 바라봄
        /*
        for (int i=0;i<obj.Count; i++)
        {
            hp_bar[i].transform.position = camera.WorldToScreenPoint(obj[i].position + new Vector3(0, 1f, 0));
        }
        */
       
    }
}
