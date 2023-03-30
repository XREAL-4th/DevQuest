using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffect;

    //충돌체 처리 함수 구현
    private void OnCollisionEnter(Collision collision)
    {
        //이펙트 프리팹 생성
        GameObject eff = Instantiate(bombEffect);
        //이펙트 프리팹 위치 설정
        eff.transform.position = transform.position;
        //자기 오브젝트를 제거
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
