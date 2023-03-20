using System;
using UnityEngine;
using Assets.Scripts.Utils.Singletons;
using System.Collections;

namespace Assets.Scripts.Utils
{
    internal class Timer : LazyDDOLSingletonMonoBehaviour<Timer>
    {
        IEnumerator SetTimeoutCoroutine(float durationInSecond, Action callback)
        {
            yield return new WaitForSeconds(durationInSecond);
            callback();
        }
        public void SetTimeout(float durationInSecond, Action callback)
        {
            StartCoroutine(SetTimeoutCoroutine(durationInSecond, callback));
        }
    }
}
