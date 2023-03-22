using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public GameObject bullet; //�Ѿ�

    public Transform firePos; //�Ѿ� �߻� ��ǥ


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.green);

        RaycastHit temp;

        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward, out temp, 200))
        {
            firePos.LookAt(temp.point);
            Debug.DrawRay(firePos.position, firePos.forward * 200.0f, Color.cyan);
        }


        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }

    }

    void Fire()
    {
        //Instantiate(bullet, firePos.position, firePos.rotation); //bullet ������ ����
        //

        Instantiate(bullet, firePos.position, firePos.rotation); //bullet ������ ����

    }

    
}
