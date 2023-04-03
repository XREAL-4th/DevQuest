using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coroutine : MonoBehaviour
{
    IEnumerator coroutine;
    GameObject freezeCircle;
    private GameObject fill;

    void Start() {
        fill = GameObject.Find("Fill");
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
        yield return new WaitForSeconds(4f);
        OffSkill();
    }

    void OnSkill() {
        freezeCircle.SetActive(true);
    }

    void OffSkill() {
        freezeCircle.SetActive(false);
        fill.GetComponent<Image>().fillAmount = 0;
    }
}
