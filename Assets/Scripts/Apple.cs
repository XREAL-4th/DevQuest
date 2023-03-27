using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField]
    AppleData appleData;
    public AppleData AppleData { set { appleData = value; }}

    public void WatchAppleInfo() {
        Debug.Log(appleData.Speed);
        Debug.Log(appleData.Jump);
    }
}
