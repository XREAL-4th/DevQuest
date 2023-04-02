using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreezeControl : MonoBehaviour
{
    private GameObject fill;
    private float time = 4f;
    
    private void Start() {
        fill = GameObject.Find("Fill");
    }

    private void Update()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, 6.0f);
        foreach (Collider c in hit) {
            if (c.name.Substring(0, 5) == "Enemy") {
                Destroy(c.gameObject);
                Destroy(c.gameObject.transform.GetChild(4));
                GameManager.instance.score += 3;
            }
        }

        time -= Time.deltaTime;
        var per = time / 4f;
        fill.GetComponent<Image>().fillAmount = per;

        //fill.fillAmount = per;
    }
}
