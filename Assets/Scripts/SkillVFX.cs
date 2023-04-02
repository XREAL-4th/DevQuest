using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillVFX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Disappear());
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(2.1f);
        Destroy(gameObject);
    }
}
