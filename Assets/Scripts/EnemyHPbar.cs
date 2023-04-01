using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPbar : MonoBehaviour
{
    Canvas hpCanvas;
    Camera hpCamera;
    RectTransform rectParent;
    RectTransform rectHp;

    //적과 얼마나 떨어진 위치에 놓을건지(높이..?)
    [HideInInspector] public Vector3 offset = Vector3.zero;

    [HideInInspector] public Transform targetTransform;

    // Start is called before the first frame update
    void Start()
    {
        hpCanvas = GetComponentInParent<Canvas>();
        hpCamera = hpCanvas.worldCamera;
        rectParent = hpCanvas.GetComponent<RectTransform>();
        rectHp = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        
        //월드 좌표를 스크린 좌표로 변환
        var screenPos = Camera.main.WorldToScreenPoint(targetTransform.position + offset);
        Debug.Log(screenPos);

        //적과 반대 방향에 있을 때(시야에 적이 안보일 때) 체력바 안보이게 하기 위함
        if (screenPos.z < 0.0f)
        {
            screenPos *= -1.0f;
        }

        //스크린 좌표를 캔버스에서 사용 가능한 좌표로 변환
        var hpPos = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectParent, screenPos, hpCamera, out hpPos);
        
        rectHp.localPosition = hpPos;
    }
}
