using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public int enemyHealth = 10;
    public ParticleSystem hitParticleSystem;
    public ParticleSystem dieParticleSystem;

    [SerializeField] private Slider healthSlider;
    // 체력 0이 되면 터지고 비활성화해야함.
    private void Start()
    {
        healthSlider.value = enemyHealth;
    }

    public void DescreaseHealth(Vector3 hitPoint)
    {
        enemyHealth -= 1;
        if (enemyHealth <= 0)
        {
            dieParticleSystem.Play();
            this.gameObject.SetActive(false);
            return;
        }
        healthSlider.value = enemyHealth;
        dieParticleSystem.transform.position = hitPoint;
        dieParticleSystem.Play();
        
    }
}
