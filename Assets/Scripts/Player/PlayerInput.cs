using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Transform fireTransform;
    public ParticleSystem fireParticleSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        Ray ray = new Ray(fireTransform.position, transform.forward); //Camera.main.ScreenPointToRay(Input.mousePosition); // 마우스 포인터 위치에서 Ray 생성
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo)) // 충돌 여부 확인
        {
            ParticleSystem ps = Instantiate(fireParticleSystem, fireTransform);
            ps.Play();
            if (hitInfo.collider.gameObject.layer == 7) // enemy Layer이면?
            {
                EnemyInfo enemyInfo = hitInfo.collider.gameObject.GetComponent<EnemyInfo>();
                enemyInfo.DescreaseHealth();
            }
            
            // 충돌한 오브젝트가 적이면 EnemyInfo에 접근해 체력 -1
        }
    }
}
