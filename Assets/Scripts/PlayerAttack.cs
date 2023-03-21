using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject firePos;  //�Ѿ� ���� ��ġ
    public GameObject PrefabBullet;
    //public float force = 5;

    private Ray ray;

    private RaycastHit hit;

    private Vector3 movePos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //���콺 Ŀ�� ��ǥ �޾ƿ���
        //if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 100.0f, 1 << 8))
        if (Input.GetMouseButtonDown(0))
        {
            movePos = hit.point;
            //Debug.Log(movePos);
            Shoot();
        }
        
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(PrefabBullet);    //������ �Ѿ� ����
        bullet.transform.position = firePos.transform.position;
        Rigidbody bulletRigid = bullet.GetComponent<Rigidbody>();
        bulletRigid.velocity = firePos.transform.forward * 50;  //�ӵ�
        //bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * force);
    }
}
