using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitControl : MonoBehaviour
{
    public GameObject popup;
    public GameObject camera;

    // private void Start() {
    //     popup.SetActive(false);
    // }

    public void OnClickQuit() {
        popup.SetActive(true);
        Debug.Log("Quit clicked");
        camera.GetComponent<CameraControl>().enabled = false;
        camera.GetComponent<RayControl>().enabled = false;
    }

    public void OnClickYes() {
        Debug.Log("Yes clicked");
        SceneManager.LoadScene("Assignment");
    }

    public void OnClickNo() {
        Debug.Log("No clicked");
        popup.SetActive(false);
        camera.GetComponent<CameraControl>().enabled = true;
        camera.GetComponent<RayControl>().enabled = true;
    }
}
