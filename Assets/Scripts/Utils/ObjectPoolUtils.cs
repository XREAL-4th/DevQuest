using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public static class ObjectPoolUtils
{
    public static ObjectPool<T> CreateMonoBehaviourPool<T>() where T : MonoBehaviour => CreateMonoBehaviourPool<T>(() => new GameObject());
    public static ObjectPool<T> CreateMonoBehaviourPool<T>(GameObject creator) where T : MonoBehaviour => CreateMonoBehaviourPool<T>(() => UnityEngine.Object.Instantiate(creator));
    public static ObjectPool<T> CreateMonoBehaviourPool<T>(Func<GameObject> creator) where T : MonoBehaviour
    {
        return new(
            () => creator().GetComponent<T>(),
            @object => @object.gameObject.SetActive(true),
            @object => @object.gameObject.SetActive(false),
            @object => UnityEngine.Object.Destroy(@object.gameObject)
        );
    }
}