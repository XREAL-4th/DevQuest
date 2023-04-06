using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameIn : MonoBehaviour
{
    [SerializeField] private TMP_InputField nicknameField;
    [SerializeField] private Button ok, start;
    private string nickname;
    
    void Start()
    {
        ok.onClick.AddListener(InputName);
        start.onClick.AddListener(GameStart);
        nickname = nicknameField.text;
    }

    // Update is called once per frame
    void Update()
    {
        if (nickname.Length > 0 && Input.GetKeyDown(KeyCode.Return)){
            InputName();
        }
    }

    private void InputName()
    {
        nickname = nicknameField.text;
        UserManager.instance.nickname = this.nickname;
    }

    private void GameStart()
    {
        SceneManager.LoadScene("Assignment");
    }
}
