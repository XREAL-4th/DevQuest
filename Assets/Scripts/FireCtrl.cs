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
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.green); //ī�޶��� position, ���� ��ġ�� Ray �׸�

        RaycastHit temp;

        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward, out temp)) // �浹�� ����Ǹ� �Ѿ��� ����������Ʈ(firePos)�� �浹�� �߻�����ġ�� �ٶ� ��.
                                                                                                         
        {
            firePos.LookAt(temp.point);
            Debug.DrawRay(firePos.position, firePos.forward, Color.cyan);
        }


        if (Input.GetMouseButtonDown(0)) //�߻��Է� �� �Ѿ��� �浹������ ���ư�
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
