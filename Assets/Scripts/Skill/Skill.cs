using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Skill : MonoBehaviour
{
    [Header("Preset")]
    [SerializeField] private Image maskImage;
    [SerializeField] private Image invalidImage;
    [SerializeField] private TextMeshProUGUI cooldownText;


    [Header("Setting")]
    public float cooltime;
    public KeyCode code;
    public GameObject activeEffect = null;

    [Header("Debug")]
    public float currentCooltime;

    private void Update()
    {
        if (Input.GetKey(code)) Active();
        if (currentCooltime > 0) currentCooltime -= Time.deltaTime;
        invalidImage.gameObject.SetActive(!IsAvaliable());
        maskImage.fillAmount = currentCooltime / cooltime;
        if (Math.Ceiling(currentCooltime) > 0)
        {
            if (Math.Ceiling(currentCooltime) > 1)
                cooldownText.SetText(Math.Ceiling(currentCooltime).ToString());
            else cooldownText.SetText((Math.Ceiling(currentCooltime * 10) / 10).ToString());
        }
        else cooldownText.SetText("");
    }

    public void Active()
    {
        if (!IsAvaliable() || currentCooltime > 0) return;
        Effect();
        OnActive();
        currentCooltime = cooltime;
    }

    protected abstract bool IsAvaliable();
    protected virtual void Effect() { }
    protected abstract void OnActive();
}