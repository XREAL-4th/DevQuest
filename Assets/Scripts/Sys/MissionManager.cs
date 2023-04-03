using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    private static MissionManager instance = null;
    private static float point;

    public enum Steps
    {
        MISSION_1,
        MISSION_END
    };
    public Steps missionStep;

    //non-lazy, DDOL
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            LoadMission();
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    private void ClearMission()
    {
        missionStep += 1;
        LoadMission();
    }

    private void LoadMission()
    {
        switch(missionStep)
        {
            case Steps.MISSION_1:
                //add UI in here
                Debug.Log("Kill all enemy");
                break;
            case Steps.MISSION_END:
                //add UI in here
                Debug.Log("End Misson");
                break;
            default:
                break;
        }
    }

    public void MissionFunction()
    {
        switch(missionStep)
        {
            case Steps.MISSION_1:
                //call when enemy destroyed
                if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) ClearMission();
                break;
            case Steps.MISSION_END:
                break;
            default:
                break;
        }
    }

    public float ReturnPoint(float a = 0)
    {
        point += a;
        return point;
    }
}
