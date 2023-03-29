using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffect;

    //�浹ü ó�� �Լ� ����
    private void OnCollisionEnter(Collision collision)
    {
        //����Ʈ ������ ����
        GameObject eff = Instantiate(bombEffect);
        //����Ʈ ������ ��ġ ����
        eff.transform.position = transform.position;
        //�ڱ� ������Ʈ�� ����
        Destroy(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
