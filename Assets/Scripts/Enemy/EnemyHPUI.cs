using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPUI : MonoBehaviour
{
    private Enemy enemy;
    public Slider hpBar;
    private RectTransform rectTransform;

    void Update()
    {
        Vector3 tmp;
        tmp = Camera.main.WorldToScreenPoint(enemy.transform.position + new Vector3(0, 0f, 0));
        if(tmp.z < -10)
        {
            if(hpBar.gameObject.activeSelf) hpBar.gameObject.SetActive(false);
        }
        else
        {
            if(!hpBar.gameObject.activeSelf) hpBar.gameObject.SetActive(true);
            rectTransform.position = tmp;
        }
        hpBar.value = enemy.hp;
    }

    public void initUI(Enemy enemy)
    {
        this.enemy = enemy;
        hpBar.maxValue = enemy.hp;
        hpBar.value = enemy.hp;
        rectTransform = hpBar.GetComponent<RectTransform>();
    }
}
