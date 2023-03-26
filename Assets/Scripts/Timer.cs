using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer;
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        timer = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Assignment" && timer <= 0)
        {
            GameQuitManager.instance.FinishGame();
        }
        timer -= Time.deltaTime;
        timerText.text = (Mathf.Ceil(timer)).ToString();
    }
}
