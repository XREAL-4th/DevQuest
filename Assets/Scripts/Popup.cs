using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    [SerializeField] private Button gameOutButton;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;
    [SerializeField] private GameObject gameoutPopup;

    void Start()
    {
        gameOutButton.onClick.AddListener(ShowPopup);
        yesButton.onClick.AddListener(Quit);
        noButton.onClick.AddListener(DownPopup);
    }
    private void ShowPopup()
    {
        gameoutPopup.SetActive(true);
    }

    private void DownPopup()
    {
        gameoutPopup.SetActive(false);
    }

    private void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#else
        Application.Quit
#endif
    }


}
