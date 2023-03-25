using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Apple", menuName="New Apple/apple")]

public class AppleData : ScriptableObject
{
    public int speed;
    public int jump;
    public GameObject prefab;

    public int Speed { get { return speed; } set { speed = value; }}
    public int Jump { get { return jump;} set { jump = value; }}
}
