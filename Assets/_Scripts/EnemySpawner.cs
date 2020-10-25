using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private EnemyManager enemyManager;
    [SerializeField]
    private float minRespawnTime = 1.0f;
    [SerializeField]
    private float maxRespawnTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        enemyManager = GetComponent<EnemyManager>();
        StartCoroutine(enemyWaves());
    }

    private void spawnEnemy()
    {
        GameObject newHazard = enemyManager.GetEnemy(new Vector3(Random.Range(-3, 3), 6.5f));
    }

    IEnumerator enemyWaves()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minRespawnTime,maxRespawnTime));
            if (enemyManager.HasEnemy())
            {
                spawnEnemy();
            }
        }
    }

}
