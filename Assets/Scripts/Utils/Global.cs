using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    internal class Global
    {
        public static IEnumerator YieldToCoroutine(YieldInstruction yield)
        {
            yield return yield;
        }

        public static YieldInstruction DummyYieldInstruction() => new();
        public static IEnumerator DummyCoroutine() => YieldToCoroutine(DummyYieldInstruction());
    }
}
