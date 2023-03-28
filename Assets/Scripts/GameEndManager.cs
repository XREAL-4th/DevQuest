using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public enum WinState
{
    Idle, Win, Lose
}

public class GameEndManager : SingletonMonoBehaviour<GameEndManager>
{
    [Header("Debug")]
    public bool isGameEnd = false;
    public WinState winState = WinState.Idle;

    private IMission[] missions;

    protected override void Awake()
    {
        base.Awake();
        missions = GetComponentsInChildren<IMission>();
    }

    private void Update()
    {
        foreach(IMission mission in missions)
        {
            if(mission.IsMissionFailed())
            {
                winState = WinState.Lose;
                if (!isGameEnd) GameEnd();
                break;
            }
            else if(mission.IsMissionCompleted())
            {
                winState = WinState.Win;
                if (!isGameEnd) GameEnd();
                break;
            }
        }
    }

    private void GameEnd()
    {
            ScreenTransitionController.Main.ChangeScene
            <ScreenFadeInTransition, ScreenFadeOutTransition>
            (winState == WinState.Win ? "GameWinScene" : "GameLoseScene", 0.5f, 1);
        isGameEnd = true;
    }
}