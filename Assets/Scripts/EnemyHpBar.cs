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
        var screenPos = Camera.main.WorldToScreenPoint(enemyTr.position + offset); //������ǥ(3D)�� ��ũ����ǥ(2D)�� ����, offset�� ������Ʈ �Ӹ� ��ġ
        if (screenPos.z < 0.0f)
        {
            screenPos *= -1.0f;
            //x, y, (z) ����ī�޶󿡼� XY�������� �Ÿ�
        }
        var localPos = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectParent, screenPos, uiCamera, out localPos); //��ũ����ǥ���� ĵ�������� ����� �� �ִ� ��ǥ�� ����?

        rectHp.localPosition = localPos;
    }
}
