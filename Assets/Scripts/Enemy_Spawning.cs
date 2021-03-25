using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawning : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject[] enemyPrefabs;
    public int count = 0;
    void Start()
    {
        InvokeRepeating("Spawn", 1f, 1f); //1 second delay per use
    }

    // Update is called once per frame
    void Spawn()
    {
        count++;
        int Enemy = Random.Range(0, enemyPrefabs.Length);
        int randSpawnPoint = Random.Range(0, spawnPoint.Length);

        Instantiate(enemyPrefabs[0], spawnPoint[randSpawnPoint].position, transform.rotation);
        Debug.Log("Enemies spawned is: " + count);
    }
}
