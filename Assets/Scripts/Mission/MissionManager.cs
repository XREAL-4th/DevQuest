using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MissionManager : SingletonMonoBehaviour<MissionManager>
{
    private Mission[] missions;

    protected override void Awake()
    {
        base.Awake();
        missions = GetComponentsInChildren<Mission>();
    }

    private void Update()
    {
        foreach (Mission mission in missions)
        {
            if (mission.IsMissionCompleted())
            {
                foreach (MissionResult result in mission.completeResults)
                    result.Run(MissionResultType.Reward);
            }

            if (mission.IsMissionFailed())
            {
                foreach (MissionResult result in mission.failResults)
                    result.Run(MissionResultType.Risk);
            }
        }
    }

}
