using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public delegate IEnumerator DebounceDelegate();
public static class InvokeUtils
{
    public static void Repeat(int times, Action<int> callback)
    {
        for (int i = 0; i < times; i++) callback(i);
    }

    public static IEnumerator RepeatDelayCoroutine(int length, float delayPerSecond, Action<int> callback)
    {
        var delay = new WaitForSeconds(delayPerSecond);

        for (int i = 0; i < length; i++)
        {
            callback(i);

            yield return delay;
        }
    }

    public static Coroutine RepeatDelay(MonoBehaviour caller, int length, float delayPerSecond, Action<int> callback)
     => caller.StartCoroutine(RepeatDelayCoroutine(length, delayPerSecond, callback)); 
    
    public static Coroutine RepeatDelay(int length, float delayPerSecond, Action<int> callback)
     => CoroutineInvoker.Instance.StartCoroutine(RepeatDelayCoroutine(length, delayPerSecond, callback));
}