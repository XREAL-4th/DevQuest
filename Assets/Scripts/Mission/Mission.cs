using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IMission
{
    public string MissionTitle { get; }
    public string MissionDescription { get; }

    public bool IsMissionFailed();
    public bool IsMissionCompleted();
}

public abstract class Mission : ScriptableObject, IMission
{
    public string missionTitle;
    public string missionDescription;

    public string MissionTitle => missionTitle;
    public string MissionDescription => missionDescription;
    public abstract bool IsMissionFailed();
    public abstract bool IsMissionCompleted();
}