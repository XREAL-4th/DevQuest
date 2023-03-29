using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultControl : MonoBehaviour
{

    public TMP_Text resultText;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.GetScore() == 3) resultText.text = "CLEAR!";
        else resultText.text = "FAIL";
    }

    // Update is called once per frame
    void Update()
    {
    }
}
