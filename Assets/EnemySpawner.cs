using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private float spawnRadius = 1, time  = 0.5f;

    public GameObject[] enemies;
    public GameObject player;

    void Start()
    {
        // StartCoroutine(SpawnAnEnemy());
    }

    bool spawned = false;

    void Update()
    {
        if(!CountTimer.instance.timeOut)
        if(!spawned){

            StartCoroutine(SpawnAnEnemy());
        }
    }

    IEnumerator SpawnAnEnemy(){
        spawned = true;
        Vector2 spawnPos = player.transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
       // Debug.Log("---spawnPos: " + spawnPos);
        yield return new WaitForSeconds(time);
        spawned = false;
        //StartCoroutine(SpawnAnEnemy());
    }
}
