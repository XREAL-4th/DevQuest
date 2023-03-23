using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public enum WinState
{
    Idle, Win, Lose
}

public class GameEndManager : DDOLSingletonMonoBehaviour<GameEndManager>
{
    [Header("Setting")]
    public Mission[] missions;

    [Header("Debug")]
    public bool isGameEnd = false;
    public WinState isWin = WinState.Idle;

    private void Update()
    {
        foreach(Mission mission in missions)
        {
            if(mission.IsMissionFailed())
            {
                isWin = WinState.Lose;
                break;
            }
            else if(mission.IsMissionCompleted())
            {
                isWin = WinState.Win;
                break;
            }
        }
    }
}