using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float minSpawnTIme;
    [SerializeField] float maxSpawnTIme;
    void Start()
    {
        
        Invoke("Spawn", Random.Range(minSpawnTIme, maxSpawnTIme));
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Spawn() {;
        GameObject clone = Instantiate(enemy, transform.position, transform.rotation);
        Invoke("Spawn", Random.Range(minSpawnTIme, maxSpawnTIme));
    }
}
