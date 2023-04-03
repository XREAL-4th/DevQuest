using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mission : MonoBehaviour
{
    public string missionTitle;
    public string missionDescription;
    public MissionResult[] completeResults, failResults;

    public string MissionTitle => missionTitle;
    public string MissionDescription => missionDescription;
    public abstract bool IsMissionFailed();
    public abstract bool IsMissionCompleted();
}