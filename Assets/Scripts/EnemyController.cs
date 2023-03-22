using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public int hp = 3;
    public GameObject vfxPrefeb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            this.gameObject.SetActive(false);
            GameObject vfx = Instantiate(vfxPrefeb) as GameObject;
            vfx.transform.position = this.transform.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            hp--;
        }
    }


}
