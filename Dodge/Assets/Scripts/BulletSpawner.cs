using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float[] spawnRateMinMax = {0.5f,3f}; // {min, max}

    private GameObject target;
    private float spawnRate;
    private float timeAfterSpawn;
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMinMax[0], spawnRateMinMax[1]);
        target = GameObject.Find("Player");
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            transform.LookAt(target.transform);
            
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            spawnRate = Random.Range(spawnRateMinMax[0], spawnRateMinMax[1]);
        }
    }
}
