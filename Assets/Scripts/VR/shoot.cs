using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    [SerializeField] private OVRGrabbable ovrGrabbable;
    //public OVRInput.Button shootingButton;

    public Transform firePos;  //�Ѿ� ���� ��ġ
    public GameObject PrefabBullet;
    //�Ѿ� �ӵ�
    private float force = 2500;
    public int damage = 5;

    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        //ovrGrabbable = gameObject.GetComponent<distance>
        //OVRInput.Axis1D.PrimaryIndexTrigger();
    }

    // Update is called once per frame
    void Update()
    {
        //trigger ���� ��
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            //dir = firePos.transform.position;
            TriggerShoot();
        }
    }
    void TriggerShoot()
    {
        GameObject bullet = Instantiate(PrefabBullet, firePos.position, firePos.rotation);    //������ �Ѿ� ����
        bullet.GetComponent<Bullet>().damage = this.damage;
        //bullet.transform.position = firePos.transform.position;
        //dir = new Vector3(0, 0, firePos.transform.position.z);
        bullet.GetComponent<Rigidbody>().AddForce(firePos.forward * force);
        //bullet.GetComponent<Rigidbody>().AddForce(dir * force);

    }
}
