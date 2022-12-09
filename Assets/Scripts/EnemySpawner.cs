using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//  Copyright © 2022 Kyo Matias, Nate Florendo. All rights reserved.
//

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRadius = 5f;
    [SerializeField] private float _time = 1.5f;

    public GameObject[] enemies;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        Vector2 spawnPos = FindObjectOfType<Player>().transform.position;
        spawnPos += Random.insideUnitCircle.normalized * _spawnRadius;

        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(_time);
        StartCoroutine(SpawnEnemy());
    }
}
