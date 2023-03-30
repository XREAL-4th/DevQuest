using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    [SerializeField]
    private GameObject speed_prefab;

    [SerializeField]
    private GameObject time_prefab;
    
    [SerializeField]
    private int numOfSpeed = 2;
    
    [SerializeField]
    private int numOfTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numOfSpeed; i++)
        {
            Instantiate(speed_prefab, new Vector3(Random.Range(2, 7), 1, Random.Range(2, 7)), Quaternion.identity);
        }
        for (int i = 0; i < numOfTime; i++)
        {
            Instantiate(time_prefab, new Vector3(Random.Range(2, 7), 1, Random.Range(2, 7)), Quaternion.identity);
        }
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
