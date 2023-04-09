using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTime = 0.5f;


    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnTime);
    }

    void SpawnEnemy()
    {
        //Vector3 spawnPosition = new Vector3(Random.Range(-26f, 65f), Random.Range(-15f, 35f), 0f);
        Vector3 spawnPosition = new Vector3(gameObject.transform.position.x + Random.Range(-10f, 10f), gameObject.transform.position.y + Random.Range(-10f, 10f), 0f);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }


}
