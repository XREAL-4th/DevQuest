using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    public float moveSpeed;
    public float destroyTime;

    public TextMeshProUGUI text;

    private Vector3 vec;


    // Update is called once per frame
    void Update()
    {
        vec.Set(text.transform.position.x, text.transform.position.y + (moveSpeed * Time.deltaTime), text.transform.position.z);
        text.transform.position = vec;

        destroyTime -= Time.deltaTime;
        
        if (destroyTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
