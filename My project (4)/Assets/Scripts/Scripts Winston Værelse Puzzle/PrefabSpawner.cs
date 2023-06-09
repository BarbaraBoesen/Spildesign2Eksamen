using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform spawnPoint;

    private bool canSpawn;
    private bool isSpawned;

    void Update()
    {
        if (canSpawn && !isSpawned && Input.GetKeyDown(KeyCode.E))
        {
            SpawnPrefab();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canSpawn = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canSpawn = false;
        }
    }

    void SpawnPrefab()
    {
        if (!isSpawned)
        {
            Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
            isSpawned = true;
        }
    }
}
