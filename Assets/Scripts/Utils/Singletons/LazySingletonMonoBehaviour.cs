﻿using UnityEditor;
using UnityEngine;

public abstract class LazySingletonMonoBehaviour<T> : SingletonMonoBehaviour<T> where T : MonoBehaviour
{
    public new static T Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject gameObject = new(typeof(T).Name);
                _instance = gameObject.AddComponent<T>();
            }
            return _instance;
        }
    }
}
