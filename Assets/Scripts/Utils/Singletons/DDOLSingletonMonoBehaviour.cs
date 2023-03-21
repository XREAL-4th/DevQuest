using UnityEditor;
using UnityEngine;

public class DDOLSingletonMonoBehaviour<T> : SingletonMonoBehaviour<T> where T : MonoBehaviour
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}
