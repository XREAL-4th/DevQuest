using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    private Transform world = null;
    [SerializeField]
    private Factory itemFactory = null;
    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }
        for (int i = 0; i<20; i++)
        {
            int randomType = Random.Range(0, 2);
            this.itemFactory.Spawn((ITEM)randomType, this.world);
        }
    }
    public GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
}
