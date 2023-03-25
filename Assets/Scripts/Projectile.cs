using System;
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
        layerMask = 7;
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
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody targetRigidbody = other.GetComponent<Rigidbody>();
        EnemyInfo enemyInfo = other.GetComponent<EnemyInfo>();

        if (targetRigidbody != null && enemyInfo != null)
        {
            targetRigidbody.AddForceAtPosition(transform.forward * speed, other.transform.position, ForceMode.Impulse);
            StartCoroutine(enemyInfo.DescreaseHealth());
        }
    }
}
