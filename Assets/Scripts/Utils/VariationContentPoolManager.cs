using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class VariationContentPoolManager<T> : DDOLSingletonMonoBehaviour<VariationContentPoolManager<T>>
    where T : VariationContentMonoBehaviour
{
    [Header("Preset")]
    [SerializeField] private GameObject basePref;
    [SerializeField] private Transform poolContainer;

    private ObjectPool<GameObject> pool;

    protected override void Awake()
    {
        base.Awake();
        
        pool = new(
            () => Instantiate(basePref, poolContainer),
            gameObject => gameObject.SetActive(true),
            gameObject => gameObject.SetActive(false),
            gameObject => Destroy(gameObject)
        );
    }

    public MBT Get<MBT, SOT>(SOT type) 
        where MBT : T, IHasScriptableObject<SOT> 
        where SOT : ScriptableObject
    {
        MBT mb = pool.Get().AddComponent<MBT>();
        mb.isAlive = true;
        mb.Type = type;
        return mb;
    }

    public void Release(T content)
    {
        content.isAlive = false;
        pool.Release(content.gameObject);
        Destroy(content);
    }
}

public interface IHasScriptableObject<SO> 
    where SO : ScriptableObject 
{
    public SO Type { get; set; }
}

public class VariationContentMonoBehaviour : MonoBehaviour
{
    public bool isAlive = true;
}
