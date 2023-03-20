using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Utils.Singletons
{
    public class LazyDDOLSingletonMonoBehaviour<T> : LazySingletonMonoBehaviour<T> where T : MonoBehaviour
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
    }
}