using System.Collections;
using UnityEngine;

public struct GameOverMissionData
{
    public bool isWin;
}

[CreateAssetMenu(fileName = "GameOverMissionResult", menuName = "MissionResults/GameOverMissionResult", order = 1)]
public class GameOverMissionResult : MissionResult
{
    public override void Run(MissionResultType type)
    {
        GameEndManager.Main.GameEnd(type == MissionResultType.Reward);
    }
}