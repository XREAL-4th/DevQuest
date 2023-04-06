using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ranking : MonoBehaviour
{
    [SerializeField] private TMP_Text timer;
    [SerializeField] private GameObject rankPrefab;
    private float score;
    private string user;
    
    void Start()
    {
        user = UserManager.instance.nickname;
    }

    public void RankingUpdate()
    {
        GameObject tmp = Instantiate(rankPrefab);
        tmp.transform.SetParent(this.transform);
        TMP_Text rank = tmp.GetComponentInChildren<TMP_Text>();
        score = timer.GetComponent<Timer>().getTime();
        rank.text = user + " : " + score.ToString("F1") + " s";
    }

}
