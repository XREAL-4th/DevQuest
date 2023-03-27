using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Set apple manager singleton
public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    GameObject apple;

    public List<AppleData> AppleDatas = new List<AppleData>();
    public GameObject applePrefab;

    private void Awake() {
        instance = this;
        apple = gameObject;
    }

    void Start() {
        SetApples();
    }

    private void SetApples() {
        int idx;

        Vector3[] coords = new Vector3[5]{
            new Vector3(0.0f, 0.0f, 4.5f),
            new Vector3(4.04f, 0.0f, 3.74f),
            new Vector3(-4.3f, 0.79f, -6.5f),
            new Vector3(-5.5f, 0.79f, -9.3f),
            new Vector3(10.0f, 0.79f, -7.4f)
        };

        foreach (AppleData e in AppleDatas) {
            idx = e.name[6] - '0';
            GameObject newApple = Instantiate(e.prefab);
            newApple.transform.position = coords[idx];   
        }
    }
}