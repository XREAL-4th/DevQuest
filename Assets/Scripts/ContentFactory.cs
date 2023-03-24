using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class ContentFactory : LazyDDOLSingletonMonoBehaviour<ContentFactory>
{

    private ObjectPool<Enemy> enemyPool;
    private ObjectPool<Item> itemPool;


    protected override void Awake()
    {
        enemyPool = ObjectPoolUtils.CreateMonoBehaviourPool<Enemy>();
        itemPool = ObjectPoolUtils.CreateMonoBehaviourPool<Item>();
    }

    public Enemy CreateEnemy() => enemyPool.Get();

    public Item CreateItem() => itemPool.Get();
}
