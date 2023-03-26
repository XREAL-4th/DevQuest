using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowScore : MonoBehaviour
{
    public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = GameQuitManager.Instance.DeadEnemy().ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
