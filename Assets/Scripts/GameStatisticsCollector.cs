using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "GameStatisticsCollector", menuName = "Globals/GameStatisticsCollector", order = 1)]
public class GameStatisticsCollector : ScriptableObject
{
    [SerializeField] private int _killCount = 0;
    public int KillCount => _killCount;

    public void IncKillCount() => _killCount++;
    public void Init()
    {
        _killCount = 0;
    }
}
