using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Image hpBar;
    //[SerializeField] private TMP_Text hpText;
    [SerializeField] private GameObject damageText;
    [SerializeField] private Enemy enemy;
    private float fullHp, currentHP;

    void Start()
    {
        canvas.worldCamera = Camera.main;
        InitHpBar();
    }

    void Update()
    {
        Enemy enemy = GetComponent<Enemy>();
        currentHP = enemy.curHp;
        UpdateHpBar();
    }

    private void InitHpBar()
    {
        fullHp = 30.0f;
        Enemy enemy = GetComponent<Enemy>();
        currentHP = enemy.curHp;
        hpBar.fillAmount = 1;
    }

    private void UpdateHpBar()
    {
        hpBar.fillAmount = currentHP / fullHp;
    }

    public void ShowDamage(float damage)
    {
        GameObject minusText = Instantiate(damageText, this.transform.position, Quaternion.identity);
        minusText.transform.SetParent(this.transform);
        minusText.GetComponent<DamageText>().damage = damage;
    }



}