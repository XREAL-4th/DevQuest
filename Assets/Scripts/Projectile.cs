using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f; // 발사체의 속도
    public float maxDistance = 50f; // 발사체가 이동할 최대 거리
    public LayerMask layerMask; // 발사체가 충돌 검출을 할 레이어

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = -transform.up * speed;
    }

    void Update()
    {
        // 발사체가 이동한 거리가 최대 거리를 넘어가면 파괴한다.
        if (Vector3.Distance(transform.position, transform.parent.position) > maxDistance)
        {
            Destroy(gameObject);
        }

        // Raycasting을 사용하여 충돌 검출을 한다.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, speed * Time.deltaTime, layerMask))
        {
            // 충돌한 객체의 Rigidbody를 가져온다.
            Rigidbody targetRigidbody = hit.collider.GetComponent<Rigidbody>();
            EnemyInfo enemyInfo = hit.collider.GetComponent<EnemyInfo>();
            // 충돌한 객체가 Rigidbody를 가지고 있다면, Rigidbody를 이용해 힘을 전달한다.
            
            if (targetRigidbody != null && enemyInfo!=null)
            {
                targetRigidbody.AddForceAtPosition(transform.forward * speed, hit.point, ForceMode.Impulse);
                enemyInfo.DescreaseHealth(hit.point);
            }

            // 발사체를 파괴한다.
            Destroy(gameObject);
        }
    }
}
