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
    private void Awake()
    {
        hitParticleSystem.gameObject.SetActive(false);
        dieParticleSystem.gameObject.SetActive(false);
    }

    private void Start()
    {
        healthSlider.value = enemyHealth;
    }

    public IEnumerator DescreaseHealth()
    {
        enemyHealth -= 1;
        if (enemyHealth <= 0)
        {
            dieParticleSystem.gameObject.SetActive(true);
            dieParticleSystem.Play();
            yield return new WaitForSeconds(dieParticleSystem.main.duration);
            
            dieParticleSystem.Stop();
            dieParticleSystem.gameObject.SetActive(false);
            EnemySpawner.instance.remainEnemyCount -= 1; // 남은 적 수 1 감소
            gameObject.SetActive(false);
        }
        healthSlider.value = enemyHealth;
        hitParticleSystem.gameObject.SetActive(true);
        
        hitParticleSystem.Play();
        yield return new WaitForSeconds(hitParticleSystem.main.duration);
        hitParticleSystem.Stop();
        hitParticleSystem.gameObject.SetActive(false);
    }
    
}
