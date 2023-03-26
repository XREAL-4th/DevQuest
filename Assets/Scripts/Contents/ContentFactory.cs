using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class ContentFactory : SingletonMonoBehaviour<ContentFactory>
{
    public GameObject dummyItem;

    private ObjectPool<Enemy> enemyPool;
    private ObjectPool<GameObject> itemPool;

    protected override void Awake()
    {
        base.Awake();

        enemyPool = ObjectPoolUtils.CreateMonoBehaviourPool<Enemy>();
        itemPool = ObjectPoolUtils.CreateGameObjectPool(dummyItem);
    }

    public Enemy CreateEnemy() => enemyPool.Get();

    public Item CreateItem(GameObject itemPref)
    {
        GameObject itemWrapGO = itemPool.Get();
        GameObject itemGO = Instantiate(itemPref, itemWrapGO.transform);
        itemGO.transform.position = itemGO.transform.position + new Vector3(0, -1f, 0);
        return itemGO.GetComponent<Item>();
    }
}
