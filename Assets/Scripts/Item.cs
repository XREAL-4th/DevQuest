using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Type { Speed, Jump };
    public Type type;
    public int value;

    private void Update()
    {
        transform.Rotate(Vector3.up * 10 * Time.deltaTime);
    }
}
