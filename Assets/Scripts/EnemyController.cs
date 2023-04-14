using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{

    public GameObject killVfxPrefab;
    public GameObject hitVfxPrefab;
    public int attackpower;

    public Slider HpBar;
    public float MaxHp;
    public float CurrentHp;
    public GameObject Damage;

    void Update()
    {
        if (CurrentHp <= 0)
        {
            this.gameObject.SetActive(false);
            GameObject vfx = Instantiate(killVfxPrefab) as GameObject;
            vfx.transform.position = this.transform.position;
            GameManager.Instance.KillEnemy();
        }

        //var screenPos= Camera.main.WorldToScreenPoint(this.transform.position + new Vector3(0, 3.5f, 0));
        //if (screenPos.z < 0.0f)
        //{
        //    screenPos *= -1.0f;
        //}
        HpBar.transform.position = this.transform.position + new Vector3(0, 3.5f, 0);
        HpBar.value = CurrentHp / MaxHp;

        Damage.transform.position = this.transform.position + new Vector3(0.6f, 4f, 0);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            CurrentHp -= GameObject.Find("Player").GetComponent<MoveControl>().attackPower;
            other.gameObject.SetActive(false);

            GameObject vfx = Instantiate(hitVfxPrefab) as GameObject;
            vfx.transform.position = this.transform.position;

            Damage.SetActive(true);

            Invoke("RemoveDamage", 0.5f);
        }
    }
    void RemoveDamage()
    {
        Damage.SetActive(false);
    }

}

