using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class DmgNumUI : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float alphaSpeed;
    [SerializeField] private float duration;
    [SerializeField] private TextMeshProUGUI text;
    private RectTransform textRectTransform;
    private Vector3 enemyPos;
    private float yPos;
    Color alpha;

    // Update is called once per frame
    void Update()
    {
        Vector3 tmp;

        yPos += moveSpeed * Time.deltaTime;
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed);
        tmp = Camera.main.WorldToScreenPoint(enemyPos + new Vector3(0, yPos, 0));

        if (tmp.z < -10)
        {
            if (text.gameObject.activeSelf) text.gameObject.SetActive(false);
        }
        else
        {
            if (!text.gameObject.activeSelf) text.gameObject.SetActive(true);
            textRectTransform.position = tmp;      
            text.color = alpha;
        }
    }

    public void initUI(float dmg, Enemy e)
    {
        alpha = text.color;
        textRectTransform = text.GetComponent<RectTransform>();
        text.text = dmg.ToString();
        enemyPos = e.transform.position;
        yPos = 0;
        Destroy(this.gameObject, duration);
    }
}
