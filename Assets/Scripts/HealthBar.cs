using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image HealthbarSprite;

    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
    }
    public void UpdateHealthBar(float MaxHealth, float CurrentHealth)
    {
        HealthbarSprite.fillAmount = CurrentHealth / MaxHealth;
    }
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - mainCam.transform.position);
    }
}
