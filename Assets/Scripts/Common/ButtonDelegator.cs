using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonDelegator : MonoBehaviour
{
    public void GameIsFin()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
				Application.Quit(); // 빌드 시 작동
#endif
    }

    public void RestartGame()
    {
        GameManager.instance.RestartGame();
    }

    public void ResumeGame()
    {
        // Cursor를 보이지않게 처리함
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Destroy(this.gameObject.transform.parent.gameObject);
    }

    public void AskExitGame()
    {
        GameObject UIPrefab = Resources.Load<GameObject>("Prefabs/ExitUI");
        //GameObject UI = Instantiate(UIPrefab, new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2), Quaternion.identity, GameObject.Find("Canvas").transform);
        
        GameObject UI = Instantiate(UIPrefab, 
            new Vector3(GameObject.Find("Canvas").transform.position.x, GameObject.Find("Canvas").transform.position.y+3.0f, GameObject.Find("Canvas").transform.position.z), 
            Quaternion.identity, 
            GameObject.Find("Canvas").transform);
    }

 
}
