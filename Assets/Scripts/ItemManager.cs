using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager sharedInstance = null;
    public SpawnPoint JumpItemSpawnPoint;
    private void Awake()
    {
        if (sharedInstance != null && sharedInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            sharedInstance = this;
        }
    }
    void Start()
    {
        SetupScene();
    }

    void SetupScene()
    {
        SpawnItem();
    }
    public void SpawnItem()
    {
        if(JumpItemSpawnPoint != null)
        {
            GameObject item = JumpItemSpawnPoint.SpawnObject();
        }
    }
}
