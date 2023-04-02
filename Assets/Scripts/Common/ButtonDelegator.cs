using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonDelegator : MonoBehaviour
{
    public void GameIsFin()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
				Application.Quit(); // ∫ÙµÂ Ω√ ¿€µø
#endif
    }

    public void RestartGame()
    {
        GameManager.instance.RestartGame();
    }
}
