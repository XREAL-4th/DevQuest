using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Utils.Transitions
{
    public abstract class ScreenTransition : MonoBehaviour
    {
        public abstract IEnumerator Run(float fadeDuration);
    }
}
