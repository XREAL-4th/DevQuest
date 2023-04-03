using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "GameStatisticsCollector", menuName = "Globals/GameStatisticsCollector", order = 1)]
public class GameStatisticsCollector : ScriptableObject
{
    [SerializeField] private int _killCount = 0;
    [SerializeField] private int _maxScore = 0;
    [SerializeField] private int _score = 0;
    public int KillCount => _killCount;
    public int MaxScore => _maxScore;
    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            _maxScore = Mathf.Max(_maxScore, _score);
        }
    }

    public void IncScore() => Score++;
    public void IncKillCount() => _killCount++;
    public void Init()
    {
        _killCount = 0;
        Score = 0;
    }
}
