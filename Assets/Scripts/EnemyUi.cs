using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUi : MonoBehaviour
{
    public Transform target;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 슬라이더 방향을 카메라의 방향과 일치
        transform.forward = target.forward;

    }
}
