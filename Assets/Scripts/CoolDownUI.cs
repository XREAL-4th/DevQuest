using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownUI : MonoBehaviour
{
    public Image fill;

    private float maxCoolDown = 10f;
    private float curCoolDown = 10f;
    // Start is called before the first frame update
    public void SetMaxCool(in float value)
    {
        maxCoolDown = value;
        UpdateFillAmount();
    }

    public void SetCurCool(in float value)
    {
        curCoolDown = value;
        UpdateFillAmount();
    }

    private void UpdateFillAmount()
    {
        fill.fillAmount = curCoolDown / maxCoolDown;
    }

    private void Update()
    {
        Debug.Log("coolImage");

        SetCurCool(curCoolDown - Time.deltaTime);

        if (curCoolDown < 0)
            curCoolDown = maxCoolDown;

    }
}
