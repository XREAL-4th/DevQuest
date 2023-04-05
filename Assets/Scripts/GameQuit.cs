using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameQuit : MonoBehaviour
{
    [SerializeField] private Button btnQuit, btnYes, btnNo;
    [SerializeField] private GameObject askPanel;

    void Start()
    {
        btnQuit.onClick.AddListener(ShowAskPanel);
        btnYes.onClick.AddListener(Quit);
        btnNo.onClick.AddListener(CancelAskPanel);
    }

    private void ShowAskPanel()
    {
        askPanel.SetActive(true);
    }
    private void CancelAskPanel()
    {
        askPanel.SetActive(false);
    }

    public void Quit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; //에디터에서 작동
        #else
				Application.Quit(); // 빌드 시 작동
        #endif
    }
}