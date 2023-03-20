using Assets.Scripts.Utils.Singletons;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Utils.Transitions
{
    public class ScreenTransitionController : DDOLSingletonMonoBehaviour<ScreenTransitionController>
    {
        readonly Dictionary<string, GameObject> m_TransitionPrefabs = new();
        UnityEngine.Canvas canvas;
        public GameObject[] transitionPrefabList;

        private void Start()
        {
            canvas = GetComponentInChildren<UnityEngine.Canvas>();
            foreach (GameObject prefab in transitionPrefabList)
            {
                m_TransitionPrefabs.Add(prefab.name, prefab);
            }
        }

        public IEnumerator StartTransition<T>(float duration) where T : ScreenTransition => StartTransition<T>(duration, Global.DummyYieldInstruction);
        public IEnumerator StartTransition<T>(float duration, Func<YieldInstruction> callbackBeforeDestroy) where T : ScreenTransition
        {
            T transition = Instantiate(m_TransitionPrefabs[typeof(T).Name], canvas.transform).GetComponent<T>();
            yield return transition.Run(duration);
            yield return callbackBeforeDestroy();
            Destroy(transition.gameObject);
        }

        public IEnumerator ChangeSceneCoroutine<TI, TO>(string sceneName, float transitionInDuration, float transitionOutDuration)
             where TI : ScreenTransition
             where TO : ScreenTransition
        {
            yield return StartTransition<TI>(transitionInDuration,
                () => SceneManager.LoadSceneAsync(sceneName)
            );
            yield return StartTransition<TO>(transitionOutDuration);
        }
        public void ChangeScene<TI, TO>(string sceneName, float transitionInDuration, float transitionOutDuration)
             where TI : ScreenTransition
             where TO : ScreenTransition
        {
            StartCoroutine(ChangeSceneCoroutine<TI, TO>(sceneName, transitionInDuration, transitionOutDuration));
        }
    }
}
