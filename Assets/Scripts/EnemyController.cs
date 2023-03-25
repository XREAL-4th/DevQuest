using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public int hp = 3;
    public GameObject vfxPrefeb;

    void Update()
    {
        if(hp == 0)
        {
            this.gameObject.SetActive(false);
            GameObject vfx = Instantiate(vfxPrefeb) as GameObject;
            vfx.transform.position = this.transform.position;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            hp--;
            other.gameObject.SetActive(false);
        }

    }


}
