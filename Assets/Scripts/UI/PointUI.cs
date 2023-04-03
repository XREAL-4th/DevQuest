using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointUI : MonoBehaviour
{
    [SerializeField] private MissionManager missionManager;
    [SerializeField] private TextMeshProUGUI text;
    private float nowpoint;
    private float nextpoint;

    private void Start()
    {
        nowpoint = -1;
        nextpoint = 0;
    }
    void Update()
    {
        nextpoint = missionManager.ReturnPoint();
        if(nextpoint != nowpoint)
        {
            nowpoint = nextpoint;
            text.text = ("Point : "+nowpoint.ToString());
        }
    }
}
