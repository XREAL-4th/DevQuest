using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Coin : MonoBehaviour
{
    private Rigidbody rigidbody;
    void Start()
    {
        Random random = new Random();
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForceAtPosition(new Vector3(random.Next(2),random.Next(2),random.Next(2)),gameObject.transform.position,ForceMode.Impulse);
    }
// Update is called once per frame

}
