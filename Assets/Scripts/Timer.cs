using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Timer : MonoBehaviour
{
    public static float timer;
    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        timer = 30f;
    }

    // Update is called once per frame
    void Update()
    {

        if (timer <= 0)
        {
            GameManager.Instance.FinishGame();
        }
        timer -= Time.deltaTime;
        timerText.text = Mathf.Ceil(timer).ToString();
       
      
    }

    
}
