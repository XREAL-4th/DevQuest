using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

public class GameEndManager : SingletonMonoBehaviour<GameEndManager>
{
    [Header("Debug")]
    public bool isGameEnd = false;
    public UnityEvent onGameStart, onGameEnd;

    private void Start()
    {
        onGameStart?.Invoke();
        Cursor.visible = false;
    }

    public void GameEnd(bool isWin)
    {
        onGameEnd?.Invoke();
        ScreenTransitionController.Main.ChangeScene
            <ScreenFadeInTransition, ScreenFadeOutTransition>
            (isWin ? "GameWinScene" : "GameLoseScene", 0.5f, 1);
        isGameEnd = true;
        Cursor.visible = true;
    }
}