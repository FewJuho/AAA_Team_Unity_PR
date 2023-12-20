using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnPeriod = 10;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn() {
        while (true) {
            yield return new WaitForSeconds(spawnPeriod);
            Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
        }
    }
}
