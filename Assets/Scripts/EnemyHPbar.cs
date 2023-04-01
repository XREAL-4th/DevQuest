using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPbar : MonoBehaviour
{
    Canvas hpCanvas;
    Camera hpCamera;
    RectTransform rectParent;
    RectTransform rectHp;

    //���� �󸶳� ������ ��ġ�� ��������(����..?)
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
        
        //���� ��ǥ�� ��ũ�� ��ǥ�� ��ȯ
        var screenPos = Camera.main.WorldToScreenPoint(targetTransform.position + offset);
        Debug.Log(screenPos);

        //���� �ݴ� ���⿡ ���� ��(�þ߿� ���� �Ⱥ��� ��) ü�¹� �Ⱥ��̰� �ϱ� ����
        if (screenPos.z < 0.0f)
        {
            screenPos *= -1.0f;
        }

        //��ũ�� ��ǥ�� ĵ�������� ��� ������ ��ǥ�� ��ȯ
        var hpPos = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectParent, screenPos, hpCamera, out hpPos);
        
        rectHp.localPosition = hpPos;
    }
}
