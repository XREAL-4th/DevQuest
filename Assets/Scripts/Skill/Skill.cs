using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Skill : MonoBehaviour
{
    [Header("Preset")]
    public Image image;

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
        image.fillAmount = 1 - currentCooltime / cooltime;
    }

    public void Active()
    {
        if (currentCooltime > 0) return;
        Effect();
        OnActive();
        currentCooltime = cooltime;
    }

    protected virtual void Effect() { }
    protected abstract void OnActive();
}