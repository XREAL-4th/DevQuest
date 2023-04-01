using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Image healthGauge;
    [SerializeField] private TMP_Text healthText;

    [SerializeField] private EnemyData enemyData;
    private float fullHp, currentHp;
    
    void Start()
    {
        //카메라 붙이기
        canvas.worldCamera = Camera.main;
        //체력 초기화
        InitHelathBar();
    }

    void Update()
    {
        //실시간 체력 반영
        currentHp = gameObject.GetComponentInParent<Enemy>().health;
        CalculateHealthBar();
    }

    //체력바 초기화
    private void InitHelathBar()
    {
        fullHp = enemyData.health;
        currentHp = gameObject.GetComponentInParent<Enemy>().health;
        healthGauge.fillAmount = 1;
        healthText.text = currentHp + "/" + fullHp;
    }

    //체력바 줄어드는 코드
    private void CalculateHealthBar()
    {
        healthGauge.fillAmount = currentHp / fullHp;
        healthText.text = currentHp + "/" + fullHp;
    }
}
