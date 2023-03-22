using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int enemyCount;

    public List<Transform> spawnArea;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        // spawnArea 배열에 등록된 스폰 장소 중 enemyCount 수 만큼 랜덤 생성
        int[] numbers = Enumerable.Range(0, spawnArea.Count-1).ToArray();
        System.Random random = new System.Random(); // 랜덤 객체 생성
        int[] randomNums = numbers.OrderBy(x => random.Next()).Take(numbers.Length-1).ToArray(); // random정렬 한 후 enemyCount 수 만큼 뽑음

        for (int i = 0; i < enemyCount; i++)
        {
            Instantiate(enemyPrefab,spawnArea[randomNums[i]]);
        }
    }
}
