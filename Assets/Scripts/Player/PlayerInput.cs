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
    public ParticleSystem skillParticleSystem;
    [SerializeField] private float skillCoolTime;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.One)) StartCoroutine(Fire());
        /*
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Fire());
        }
                
        if (Input.GetKeyDown(KeyCode.Q)&& !GameManager.instance.isCooldown)
        {
            StartCoroutine(FlashBang());
        }*/
    }

    IEnumerator Fire()
    {   
        GameObject gameObject = Instantiate(projectilePrefab,fireTransform.position,Quaternion.identity,null); 
        fireParticleSystem.Play();
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

    IEnumerator FlashBang()
    {
        // 코루틴으로 쿨타임, vfx 
        KnokBack();
        GameManager.instance.isCooldown = true;
        GameManager.instance.SkillCoolTimeReset();
        yield return new WaitForSeconds(EnemySpawner.instance.scriptable.skillCoolTime);
        GameManager.instance.isCooldown = false;
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
            GameManager.instance.playerScore += 1;
            collision.gameObject.SetActive(false);
        }
    }

    void KnokBack()
    {
        Debug.Log("KnockBack!!");
        Collider[] colliders= Physics.OverlapBox(transform.position + transform.forward * 2f, Vector3.one * 5, Quaternion.identity);
        foreach (var c in colliders)
        {
            if (c.gameObject.TryGetComponent(out Rigidbody rb))
            {
                skillParticleSystem.Play();
                if (rb.gameObject.layer == 7)
                {
                    rb.AddForce(-rb.transform.forward * 2000f); ;
                }
            }
        }
    }

    /*
    private void OnDrawGizmosSelected()
    {
        Gizmos.color= new Color(0f, 1f, 0f, 0.5f);
        Gizmos.DrawCube(transform.position + transform.forward*2f,Vector3.one*5);
    }*/
}
