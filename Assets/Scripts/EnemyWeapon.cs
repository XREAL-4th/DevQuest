using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    float time = 0;

    private void Start()
    {
        //StartCoroutine(Disappear());
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > 3)
        { 
        Destroy(gameObject);
        }
    }

    public void Launch(Vector3 speed)
    {
        GetComponent<Rigidbody>().AddForce(speed);
    }

    /*IEnumerator Disappear()
    {
        yield return new WaitForSeconds(4f);
    }*/
}
