using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform fireTransform;
    public ParticleSystem fireParticleSystem;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        Instantiate(projectilePrefab,fireTransform); 
        fireParticleSystem.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8) // layer 8 => coin
        {
            GameManager.instance.remainCoin += 1;
            collision.gameObject.SetActive(false);
        }else if (collision.gameObject.layer == 9) // layer 9 => fevertime
        {
            GameManager.instance.moveSpeed *= 1.5f;
            collision.gameObject.SetActive(false);
        }
        
    }
}