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
    public WinState isWin = WinState.Idle;

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