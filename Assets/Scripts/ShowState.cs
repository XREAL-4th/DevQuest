using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowState : MonoBehaviour
{
    public Text ScoreText;
    public Text SpeedText;
    public Text PowerText;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = GameManager.Instance.DeadEnemy().ToString();
        SpeedText.text = Mathf.Ceil(player.GetComponent<MoveControl>().moveSpeed).ToString();
        PowerText.text = player.GetComponent<MoveControl>().attackPower.ToString();
    }
}
