using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    //�Ѿ� ����Ʈ ������Ʈ
    public GameObject bulletEffect;
    //�Ѿ� ����Ʈ ��ƼŬ �ý���
    ParticleSystem ps;
    //���ݷ�
    public int weaponPower = 5;

    // Start is called before the first frame update
    void Start()
    {
        ps = bulletEffect.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //���콺 ���� ��ư �Է�
        if (Input.GetMouseButtonDown(0))
        {
            //���� �����ϰ� �߻�� ��ġ�� ���� ����
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            //���̰� �ε��� ����� ���� ����
            RaycastHit hitInfo = new RaycastHit();

            //���� �ε��� ��ü ������ �ǰ� ����Ʈ ǥ��
            if (Physics.Raycast(ray, out hitInfo))
            {
                //���� �ε��� ��� ���̾� Enemy�̸� Damage �Լ� ����
                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    EnemyAttack eATK = hitInfo.transform.GetComponent<EnemyAttack>();
                    eATK.HitEnemy(weaponPower);
                    bulletEffect.transform.position = hitInfo.point;
                    ps.Play();
                    
                }
                else
                {
                    bulletEffect.transform.position = hitInfo.point;
                    //�ǰ� ����Ʈ�� forward ������ ���̰� �ε��� ������ �������� �߻�. �浹 ������ ����� ��ġ
                    bulletEffect.transform.forward = hitInfo.normal;
                    ps.Play();
                    
                }
            }
        }
    }
}
