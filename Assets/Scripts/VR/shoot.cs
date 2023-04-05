using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    [SerializeField] private OVRGrabbable ovrGrabbable;
    //public OVRInput.Button shootingButton;

    public GameObject firePos;  //ÃÑ¾Ë »ý¼º À§Ä¡
    public GameObject PrefabBullet;
    //ÃÑ¾Ë ¼Óµµ
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
        //trigger ´©¸¦ ¶§
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            TriggerShoot();
        }
    }
    void TriggerShoot()
    {
        GameObject bullet = Instantiate(PrefabBullet);    //ÇÁ¸®ÆÕ ÃÑ¾Ë »ý¼º
        bullet.GetComponent<Bullet>().damage = this.damage;
        bullet.transform.position = firePos.transform.position;
        bullet.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        //bullet.GetComponent<Rigidbody>().AddForce(dir * force);

    }
}
