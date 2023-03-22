using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public int BulletMax;           //�Ѿ� �ִ� ��
    public int BulletNow;           //���� �Ѿ� ��

    public float BetweenShots;      //�߻簣�� (ms)
    public float ReloadTime;        //������ �ӵ� (s)
    public float muzzleVelocity;    //�Ѿ� �ӵ� 
    public float nextShotTime = 0f;     //�Ѿ� �߻� ������ ���� ����
    public float nextReloadTime = 0f;      //��  ������ ������ ���� ����

    public bool ReloadValue = false;
    public RaycastHit hitInfo;

    public ParticleSystem muzzleFlash;
    public Camera mainCam;
    public GameObject hitEffect;

    public Enemy Enemy;


    //�� �߻� �Լ�
    public void Shoot()
    {
        if (BulletNow > 0)
        {
            //�Ѿ� ���� 1�� �̻��� ���
            Debug.Log("Bullet now 0 over!");

            if (ReloadValue == false && Time.time > nextShotTime)
            {
                
                //������ �ð�, �� �߻� ������ �ð��� ���� ���
                nextShotTime = Time.time + BetweenShots/1000;

                BulletNow -= 1;
                muzzleFlash.Play();
                Hit();
            }

        }
        else
        {
            if (ReloadValue == false)
            {
                //�Ѿ� �� 0��, ���������� ����
                Reload();
                Debug.Log("Bullet is 0. Reload Bullet Start!");
            }
        }
    }

    //�� ������ �Լ�
    public void Reload()
    {
        nextReloadTime = Time.time + 2;
        ReloadValue = true;
        Debug.Log("Reload Time is " + nextReloadTime);
    }
    private void Hit()
    {
        // ī�޶� ���� ��ǥ
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hitInfo))
        {
            GameObject clone = Instantiate(hitEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(clone, 2f);
            if(hitInfo.transform.tag == "Enemy")
            {
                hitInfo.transform.GetComponent<Enemy>().EnemyAttacked();
            }
        }
    }

}