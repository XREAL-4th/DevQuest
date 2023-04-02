using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayernameInput : MonoBehaviour
{
    public InputField playerName; 
    // Start is called before the first frame update
    public void SetPlayername()
    {
        GameManager.Instance.SetPlayerName(playerName.text);
    }
}
