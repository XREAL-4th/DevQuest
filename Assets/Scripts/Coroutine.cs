using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutine : MonoBehaviour
{
    IEnumerator coroutine;
    GameObject freezeCircle;

    void Start() {
        freezeCircle = GameObject.Find("Freeze");
        freezeCircle.SetActive(false);
    }

    void Update()
    {
        if (GameManager.instance.score % 5 == 0 && GameManager.instance.score > 0) {
            coroutine = FreezeDucks();
            StartCoroutine(coroutine);
        }
    }

    IEnumerator FreezeDucks() {
        OnSkill();
        yield return new WaitForSeconds(3f);
        OffSkill();
    }

    void OnSkill() {
        freezeCircle.SetActive(true);
    }

    void OffSkill() {
        freezeCircle.SetActive(false);
    }
}
