using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Header("Pool Setup")]
    [SerializeField, Tooltip("Prefab for Spawning Enemies")] GameObject enemyPrefab;
    [SerializeField, Tooltip("Pool Size"), Range(0, 50)] int poolSize = 5;
    [SerializeField, Tooltip("Delay Between Spawns"), Range(0.1f, 30f)] float spawnTimer = 1f;

    GameObject[] pool;

    void Awake()
    {
        PopulatePool();
    }

    void Start()
    {
        StartCoroutine(InstantiateEnemy());
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++) {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    void EnableObjectInPool()
    {
        foreach (GameObject obj in pool) {
            if (!obj.activeInHierarchy) {
                obj.SetActive(true);
                break;
            }
        }
    }

    IEnumerator InstantiateEnemy()
    {
        while (Application.isPlaying) {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
