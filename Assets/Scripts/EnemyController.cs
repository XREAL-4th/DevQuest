using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public int hp;
    public GameObject killVfxPrefab;
    public GameObject hitVfxPrefab;
    public int attackpower;

    void Update()
    {
        if (hp <= 0)
        {
            this.gameObject.SetActive(false);
            GameObject vfx = Instantiate(killVfxPrefab) as GameObject;
            vfx.transform.position = this.transform.position;
            GameQuitManager.Instance.KillEnemy();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            hp -= GameObject.Find("Player").GetComponent<MoveControl>().attackPower;
            other.gameObject.SetActive(false);

            GameObject vfx = Instantiate(hitVfxPrefab) as GameObject;
            vfx.transform.position = this.transform.position;
        }
    }

}

