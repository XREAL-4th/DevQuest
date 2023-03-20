using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts;

namespace Assets.Scripts.Utils.Singletons
{
    internal class SingleCoroutineController
    {
        Coroutine m_CurrentCoroutine;

        readonly Func<IEnumerator> m_CoroutineInvoker;

        public SingleCoroutineController(): this(Global.DummyCoroutine) {}
        public SingleCoroutineController(Func<IEnumerator> coroutineInvoker)
        {
            m_CoroutineInvoker = coroutineInvoker;
        }


        public void Start(bool restartOnDuplicated = false)
            => Start(m_CoroutineInvoker, restartOnDuplicated);

        public void Start(IEnumerator coroutine, bool restartOnDuplicated = false)
            => Start(() => coroutine, restartOnDuplicated);

        public void Start(Func<IEnumerator> coroutineInvoker, bool restartOnDuplicated = false)
        {
            if (restartOnDuplicated) Stop();
            IEnumerator coroutineWrapper() 
            {
                yield return coroutineInvoker();
                m_CurrentCoroutine = null;
            }
            m_CurrentCoroutine ??= CoroutineInvoker.Instance.StartCoroutine(coroutineWrapper());
        }
        public void Stop()
        {
            if (m_CurrentCoroutine != null)
            {
                CoroutineInvoker.Instance.StopCoroutine(m_CurrentCoroutine);
                m_CurrentCoroutine = null;
            }
        }
    }
}
