using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : DDOLSingletonMonoBehaviour<ScoreManager>
{
    private int _maxScore = 0;
    private int _score = 0;
    public int MaxScore => _maxScore;
    public int Score {
        get => _score;
        set {
            _score = value;
            _maxScore = Mathf.Max(_maxScore, _score);
        }
    }
}
