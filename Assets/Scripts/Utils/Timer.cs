using System;
using UnityEngine;
using System.Collections;

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
