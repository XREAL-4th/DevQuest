using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class EnemyAI : MonoBehaviour{

    NavMeshAgent nav;
    GameObject target;
 
    void Start () {
        nav = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");
    }
    
    
    void Update () {
        if (nav.destination != target.transform.position)
        {
            nav.SetDestination (target.transform.position);
        }
        else
        {
            nav.SetDestination (transform.position);
        }
    }
}
 
