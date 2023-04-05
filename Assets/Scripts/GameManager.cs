using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject gameoverText;
    [SerializeField] GameObject timeBarObject;
    public Image timeBar;
    //public GameObject otherGameObject;
  


    [SerializeField] float setTime = 300f; 
    float timeLeft;

    public GameObject player;

    static GameManager instance = null;

    public static GameManager Instance()
    {
        return instance;
    }



    void Awake()
    {
        if(instance == null) 
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        //DontDestroyOnLoad(this); 
    }

    private void Start()
    {
        gameoverText.SetActive(false);
        //timeBar = timeBarObject.GetComponent<Image>();
        timeLeft = setTime;
    }

    private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime; 
            timeBar.fillAmount = timeLeft / setTime; 
        }

        else
        {
            gameoverText.SetActive(true);
            Time.timeScale = 0;

            GameOver();
            
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        Application.Quit();
        //Quit();
    }

}
