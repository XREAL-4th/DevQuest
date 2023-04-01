using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyDamageText : MonoBehaviour
{
    [SerializeField] private TMP_Text damageText;
    [SerializeField] private float destroyTime;
    public int damage;
    void Start()
    {
        destroyTime = 1.0f;
        transform.localScale = new Vector3(1, 1, 1);
        ShowDamageText();
        Invoke("DestroyObject", destroyTime);
    }

    void Update()
    {
        //위로 올라가는 모션
        transform.position += Vector3.up * Time.deltaTime;
    }

    public void ShowDamageText()
    {   
        damageText.text = "-" + damage;
    }
    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
