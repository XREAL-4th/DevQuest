using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpBar : MonoBehaviour
{
    private Camera uiCamera;
    private Canvas canvas;
    private RectTransform rectParent;
    private RectTransform rectHp;

    public Vector3 offset = Vector3.zero;
    public Transform enemyTr;
    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        uiCamera = canvas.worldCamera;
        rectParent = canvas.GetComponent<RectTransform>();
        rectHp = this.gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var screenPos = Camera.main.WorldToScreenPoint(enemyTr.position + offset); //월드좌표(3D)를 스크린좌표(2D)로 변경, offset은 오브젝트 머리 위치
        if (screenPos.z < 0.0f)
        {
            screenPos *= -1.0f;
            //x, y, (z) 메인카메라에서 XY평면까지의 거리
        }
        var localPos = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectParent, screenPos, uiCamera, out localPos); //스크린좌표에서 캔버스에서 사용할 수 있는 좌표로 변경?

        rectHp.localPosition = localPos;
    }
}
