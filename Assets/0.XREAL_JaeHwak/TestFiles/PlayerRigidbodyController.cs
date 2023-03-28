using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigidbodyController : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        // 이동하고자 하는 방향 계산
        Vector3 inputDir = new Vector3(hAxis, 0, vAxis).normalized;

        _rb.MovePosition(_rb.position + inputDir * moveSpeed * Time.deltaTime);

        // 이동하는 방향으로 회전
        transform.LookAt(transform.position + inputDir);
    }
}