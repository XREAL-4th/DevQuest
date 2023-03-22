using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointShoot : MonoBehaviour
{
    public static Vector3 targetPos;
 
    void Update () {
        //마우스클릭
        if( Input.GetMouseButton (0))
        {
            //카메라가 보는 방향, 시야 가져옴
            Vector3 mouse = Input.mousePosition;
            mouse.z = GetComponent<Camera>().farClipPlane; 

            //보고있는 화면에 맞춰서 좌표를 바꿔줌
            Vector3 dir = GetComponent<Camera>().ScreenToWorldPoint(mouse);
            
 
            RaycastHit hit;
            if(Physics.Raycast(transform.position,dir,out hit,mouse.z))
            {
                // 타겟 좌표 = 레이캐스트가 충돌된 곳
                targetPos = hit.point; 
            }
        }
    }
}
