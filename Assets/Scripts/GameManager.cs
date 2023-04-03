using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private float GameTime = 10;
    public Text GameTimeText;
    void Update()
    {
     if((int)GameTime==0)
        {
            Debug.Log("종료");
            GameTimeText.text = "게임 종료";
            //SceneManager.LoadScene("Ending");
        }
     else
        {
            GameTime -= Time.deltaTime;
            Debug.Log((int)GameTime);
            GameTimeText.text = "Time: " + (int)GameTime;
        }
    }
}
