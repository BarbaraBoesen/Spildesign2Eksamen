using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PrefabSpawnerDialogueClock : MonoBehaviour
{
    public GameObject[] prefabsToSpawn;
    public Transform spawnPoint;

    private bool canSpawn;

    void Update()
    {
        if (canSpawn && Input.GetKeyDown(KeyCode.T))
        {
            SpawnPrefabs();
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

    void SpawnPrefabs()
    {
        foreach (GameObject prefab in prefabsToSpawn)
        {
            Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
