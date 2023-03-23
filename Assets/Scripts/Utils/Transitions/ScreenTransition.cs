using System;
using System.Collections;
using UnityEngine;

public abstract class ScreenTransition : MonoBehaviour
{
    public abstract IEnumerator Run(float fadeDuration);
}
