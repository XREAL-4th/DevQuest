using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public Text Playername;
    void Start()
    {
        Playername.text = GameManager.Instance.GetPlayerName();   
    }

}
