using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private GameObject[] enemyPrefab;

    public GameObject enemy;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (true)
        {
            yield return wait;

            Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }

}
