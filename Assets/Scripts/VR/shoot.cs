using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    [SerializeField] private OVRGrabbable ovrGrabbable;
    //public OVRInput.Button shootingButton;

    public Transform firePos;  //총알 생성 위치
    public GameObject PrefabBullet;
    //총알 속도
    private float force = 2500;
    public int damage = 5;

    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        //ovrGrabbable = GetComponent<OVRGrabbable>();
        //ovrGrabbable = gameObject.GetComponent<distance>
        //OVRInput.Axis1D.PrimaryIndexTrigger();
    }

    // Update is called once per frame
    void Update()
    {
        //trigger 누를 때
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            //dir = firePos.transform.position;
            TriggerShoot();
        }
    }
    void TriggerShoot()
    {
        GameObject bullet = Instantiate(PrefabBullet, firePos.position, firePos.rotation);    //프리팹 총알 생성
        bullet.GetComponent<Bullet>().damage = this.damage;
        //bullet.transform.position = firePos.transform.position;
        //dir = new Vector3(0, 0, firePos.transform.position.z);
        bullet.GetComponent<Rigidbody>().AddForce(firePos.forward * force);
        //bullet.GetComponent<Rigidbody>().AddForce(dir * force);

    }
}
