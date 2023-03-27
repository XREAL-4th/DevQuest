using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class EnemySpawner : SingletonMonoBehaviour<EnemySpawner>
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject feverPrefab;
    [SerializeField] private int enemyCount;
    [SerializeField] private int feverTimeItemCount;
    public int remainEnemyCount;

    public List<Transform> enemySpawnArea;
    public List<Transform> feverSpawnArea;

    public scriptableObject scriptable;
    // Start is called before the first frame update
    void Start()
    {
        enemyCount = scriptable.enemyCount;
        feverTimeItemCount = scriptable.feverTimeItemNum;
        remainEnemyCount = enemyCount;
        SpawnEnemy();
        SpawnFeverTimeItem();
    }

    // Update is called once per frame
    void Update()
    {
        if (remainEnemyCount == 0)
        {
            GameManager.instance.GameClear();
        }
    }

    void SpawnEnemy()
    {
        // spawnArea 배열에 등록된 스폰 장소 중 enemyCount 수 만큼 랜덤 생성
        int[] numbers = Enumerable.Range(0, enemySpawnArea.Count-1).ToArray();
        System.Random random = new System.Random(); // 랜덤 객체 생성
        int[] randomNums = numbers.OrderBy(x => random.Next()).Take(numbers.Length-1).ToArray(); // random정렬 한 후 enemyCount 수 만큼 뽑음

        for (int i = 0; i < enemyCount; i++)
        {
            Instantiate(enemyPrefab,enemySpawnArea[randomNums[i]]);
        }
    }

    void SpawnFeverTimeItem()
    {
        int[] numbers = Enumerable.Range(0, feverSpawnArea.Count - 1).ToArray();
        Random random = new Random();
        int[] randomNums = numbers.OrderBy(x => random.Next()).Take(numbers.Length - 1).ToArray();

        for (int i = 0; i < feverTimeItemCount; i++)
        {
            Instantiate(feverPrefab, feverSpawnArea[randomNums[i]]);
        }
    }
}
