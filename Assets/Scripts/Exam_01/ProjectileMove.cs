using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float speed;
    public float fireRate;
    public GameObject hitPrefab;

    // Update is called once per frame
    void Update()
    {
        if(speed != 0)
        {
            transform.position += transform.forward * (speed*Time.deltaTime);
        } else
        {
            Debug.Log("No Speed");
        }
    }

    void OnCollisionEnter(Collision co)
    {
        //���� źȯ�� �÷��̾ ���� �ۿ��� ���� �ʵ��� ������Ʈ ������ �� ��� źȯ�� ���� �и� ������ ������ �� �ִ�.
        if(co.gameObject.name != "Player")
        {
            Debug.Log("�浹");
            Debug.Log(co.gameObject.name);
            speed = 0;
            
            ContactPoint contact = co.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;

            if(hitPrefab != null)
            {
                var hitVFX = Instantiate(hitPrefab, pos, rot);
                var psHit = hitVFX.GetComponent<ParticleSystem>();
                if (psHit != null)
                    Destroy(hitVFX, psHit.main.duration);
                else
                {
                    var psChild = hitVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                    Destroy(hitVFX, psChild.main.duration);
                }
            }

            Destroy(gameObject);
        }

    }

}
