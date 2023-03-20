using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Utils.Singletons
{
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected static T _instance;
        public static T Instance => _instance;

        protected virtual void Awake()
        {
            _instance = this as T;
        }
    }
}