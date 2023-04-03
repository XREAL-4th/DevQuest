using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFire : MonoBehaviour
{
    


    //����ź �߻� ��ġ ����
    public GameObject firePosition;
    //����ź ������Ʈ ����
    public GameObject bombFactory;
    //��ô �Ŀ�
    public float throwPower = 15f;
    //����ź ���ݷ�
    public int bombPower = 15;

    //�Ѿ� ����Ʈ ������Ʈ
    public GameObject bulletEffect;
    //�Ѿ� ����Ʈ ��ƼŬ �ý���
    ParticleSystem ps;
    //�Ѿ� ���ݷ�
    public int weaponPower = 5;
    
    //������ ���� ����
    public bool isDelay;
    //������ �ð� ����
    public float delayTime = 5f;
    float timer = 0f;

    
    // Start is called before the first frame update
    void Start()
    {
        ps = bulletEffect.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //���콺 ������ ��ư �Է�
        if (Input.GetMouseButtonDown(1))
        {
            
            if (!isDelay)
            {
                isDelay = true;
                GameObject bomb = Instantiate(bombFactory);
                bomb.transform.position = firePosition.transform.position;
                Rigidbody rb = bomb.GetComponent<Rigidbody>();
                //ī�޶��� ���� �������� ���⿡ ������ ���� ����
                rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);

            

            
            //�ڷ�ƾ �Լ� ����
            StartCoroutine(CountAttackDelay());
        }
        else
        {
            Debug.Log("Delay");
        }
        
        
        }
        
        if (isDelay)
        {
            timer += Time.deltaTime;
            if (timer >= delayTime)
            {
                timer = 0f;
                isDelay = false;
            }
        }
        



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
    
    IEnumerator CountAttackDelay()
    {
        yield return new WaitForSeconds(delayTime);
        isDelay = false;

    }
}
