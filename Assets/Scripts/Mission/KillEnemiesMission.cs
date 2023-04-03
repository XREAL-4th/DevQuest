using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class KillEnemiesMission : Mission
{
    [SerializeField] private int amounts;

    public override bool IsMissionCompleted() => GameStatisticsManager.Main.Collector.KillCount >= amounts;

    public override bool IsMissionFailed() => false;
}
