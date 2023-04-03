using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamageText : MonoBehaviour
{
    [SerializeField] private TMP_Text damageText;
    [SerializeField] private float destroyTime;
    public float damage;

    void Start()
    {
        destroyTime = 1.0f;
        transform.localScale = new Vector3(1, 1, 1);
        ShowDamage();
        Invoke("DestroyObject", destroyTime);
    }

    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime;
    }

    public void ShowDamage()
    {
        damageText.text = "-" + damage;
    }
    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
