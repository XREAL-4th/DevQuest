using System;
using UnityEditor;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T _instance;
    public static T Instance => _instance;

    protected virtual void Awake()
    {
        _instance = this as T;
    }
}
