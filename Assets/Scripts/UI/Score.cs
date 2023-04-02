using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText, maxScoreText;

    private void Update()
    {
        scoreText.SetText($"Score: {GameStatisticsManager.Main.Collector.Score}");
        maxScoreText.SetText($"Max Score: {GameStatisticsManager.Main.Collector.MaxScore}");
    }
}
