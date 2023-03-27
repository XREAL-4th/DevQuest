using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public CanvasGroup gameEndBackGroundImageCanvasGroup;

    float m_Timer;
    
    void Update()
    {
        GameObject[] chtargets = GameManager.instance.targets;
        if (chtargets.Length == 0)
            GameOver();
    }

    void GameOver()
    {
        m_Timer += Time.deltaTime;
        gameEndBackGroundImageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
                Application.Quit();
    }
}
