using System.Collections;
using UnityEngine;

public enum MissionResultType
{
    Reward, Risk, Custom
}

public abstract class MissionResult : ScriptableObject
{
    public abstract void Run(MissionResultType type);
}
