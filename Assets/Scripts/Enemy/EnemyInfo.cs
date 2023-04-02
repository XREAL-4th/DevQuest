using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class EnemyInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public int enemyHealth = 10;
    public ParticleSystem hitParticleSystem;
    public ParticleSystem dieParticleSystem;
    public GameObject coinPrefab;

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
        if (enemyHealth == 0)
        {
            DropCoin();
            dieParticleSystem.gameObject.SetActive(true);
            dieParticleSystem.Play();
            yield return new WaitForSeconds(dieParticleSystem.main.duration);
            
            dieParticleSystem.Stop();
            dieParticleSystem.gameObject.SetActive(false);
            EnemySpawner.instance.remainEnemyCount -= 1; // 남은 적 수 1 감소
            Debug.Log(EnemySpawner.instance.remainEnemyCount);
            gameObject.SetActive(false);
        }
        healthSlider.value = enemyHealth;
        hitParticleSystem.gameObject.SetActive(true);
        
        hitParticleSystem.Play();
        yield return new WaitForSeconds(hitParticleSystem.main.duration);
        hitParticleSystem.Stop();
        hitParticleSystem.gameObject.SetActive(false);
    }

    void DropCoin()
    {
        Random random = new Random();
        for (int i = 0; i < random.Next(5); i++)
        {
            Instantiate(coinPrefab,gameObject.transform.position,quaternion.identity,null);
        }
    }
}
