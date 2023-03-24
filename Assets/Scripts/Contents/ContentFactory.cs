using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class ContentFactory : SingletonMonoBehaviour<ContentFactory>
{
    public GameObject dummyItem;

    private ObjectPool<Enemy> enemyPool;
    private ObjectPool<Item> itemPool;

    protected override void Awake()
    {
        base.Awake();

        enemyPool = ObjectPoolUtils.CreateMonoBehaviourPool<Enemy>();
        itemPool = ObjectPoolUtils.CreateMonoBehaviourPool<Item>(dummyItem);
    }

    public Enemy CreateEnemy() => enemyPool.Get();

    public Item CreateItem(ItemType type)
    {
        Item item = itemPool.Get();
        Object.Instantiate(type.prefab, item.transform);
        return item;
    }
}
