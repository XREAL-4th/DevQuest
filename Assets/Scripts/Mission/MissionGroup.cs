using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MissionGroup : Mission
{
    public Mission[] missions;

    public override bool IsMissionCompleted() => missions.All((mission) => mission.IsMissionCompleted());

    public override bool IsMissionFailed() => missions.Any((mission) => mission.IsMissionFailed());
}