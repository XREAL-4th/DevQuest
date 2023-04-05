using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    private OVRGrabbable ovrGrabbable;
    public OVRInput.Button shootingButton;

    public GameObject firePos;  //�Ѿ� ���� ��ġ
    public GameObject PrefabBullet;
    //�Ѿ� �ӵ�
    private float force = 5;
    public int damage = 5;

    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        ovrGrabbable = OVRInput.Axis1D.PrimaryIndexTrigger();
    }

    // Update is called once per frame
    void Update()
    {
        //trigger ���� ��
        if (ovrGrabbable.isGrabbed && OVRInput.GetDown(shootingButton, ovrGrabbable.grabbedBy.GetController()))
        {
            TriggerShoot();
        }
    }
    void TriggerShoot()
    {
        GameObject bullet = Instantiate(PrefabBullet);    //������ �Ѿ� ����
        bullet.GetComponent<Bullet>().damage = this.damage;
        bullet.transform.position = firePos.transform.position;
        //bullet.GetComponent<Rigidbody>().AddForce(dir * force);

    }
}
