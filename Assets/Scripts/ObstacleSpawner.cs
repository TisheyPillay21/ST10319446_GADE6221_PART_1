using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private GameObject[] level2ObstaclePrefabs;
    [SerializeField] private int initalObstacleCount = 10;

    public static bool obstacleSpawned = false;
    public static float randomZ = 13;
    private int i = 0;
    private float spawnCounter = 0;

    private Vector3 spawnPosition = Vector3.zero;

    private void SpawnInitialObstacles()
    {
        for (int i = 0; i < initalObstacleCount; i++)
        {
            SpawnObstacles();
        }
    }
    private void SpawnObstacles()
    {
        Debug.Log("RANDOM Z CREATED");

        
        
        Debug.Log("IN THE FOR LOOP");
        Debug.Log("SPAWN POSITION CREATED");

        float xLimits = 0f;
        float xLimits2 = 0f;

        int index;

        if (PlatformSpawner.level2 == false)
        {
            index = Random.Range(0, obstaclePrefabs.Length);
        }
        else
        {
            index = Random.Range(0, level2ObstaclePrefabs.Length);
        }

        float randomX = 0f;

        if (PlatformSpawner.level2 == false)
        {
            if (index == 0)
            {
                xLimits = 1.4f;
                randomX = Random.Range(-xLimits, xLimits);
            }
            else if (index == 1)
            {
                xLimits = -2.8f;
                xLimits2 = 0.9f;
                randomX = Random.Range(xLimits, xLimits2);
            }
            else if (index == 2)
            {
                xLimits = -1.9f;
                xLimits2 = 1.8f;
                randomX = Random.Range(xLimits, xLimits2);
            }
            else if (index == 3)
            {
                xLimits = -2.1f;
                xLimits2 = 0.2f;
                randomX = Random.Range(xLimits, xLimits2);
            }
            else if (index == 4)
            {
                xLimits = 1.5f;
                randomX = Random.Range(-xLimits, xLimits);
            }
            else if (index == 5)
            {
                xLimits = -3f;
                xLimits2 = 1f;
                randomX = Random.Range(xLimits, xLimits2);
            }
        }
        else
        {
            if (index == 0)
            {
                xLimits = 1.4f;
                randomX = Random.Range(-xLimits, xLimits);
            }
            else if (index == 1)
            {
                xLimits = -0.8f;
                xLimits2 = 1.6f;
                randomX = Random.Range(xLimits, xLimits2);
            }
            else if (index == 2)
            {
                xLimits = -1.9f;
                xLimits2 = 1.8f;
                randomX = Random.Range(xLimits, xLimits2);
            }
            else if (index == 3)
            {
                xLimits = -2.1f;
                xLimits2 = 0.2f;
                randomX = Random.Range(xLimits, xLimits2);
            }
            else if (index == 4)
            {
                xLimits = 1.5f;
                randomX = Random.Range(-xLimits, xLimits);
            }
        }

            ///int randomX = Random.Range(-2, 2);
            ///

        spawnPosition = new Vector3(randomX, 0, randomZ);

        randomZ += 16;

        if (PlatformSpawner.level2 == false)
        {
            GameObject newObstacleGameObject = Instantiate(obstaclePrefabs[index], spawnPosition, Quaternion.identity);
            Obstacle obstacle = newObstacleGameObject.GetComponent<Obstacle>();
        }
        else
        {
            GameObject newObstacleGameObject = Instantiate(level2ObstaclePrefabs[index], spawnPosition, Quaternion.identity);
        }

        obstacleSpawned = true;
        Debug.Log("OBSTACLE SPAWNED");
            
            
        

        // int obstacleSpawnIndex = Random.Range(2, 5);
        //Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // int index = Random.Range(0, obstaclePrefabs.Length);
        // Instantiate(obstaclePrefabs[index], spawnPoint.position, Quaternion.identity, transform);
    }

    private void OnEnable()
    {
        Platform.OnPlatformLeft += OnPlaformLeftHandler;
    }

    private void OnDisable()
    {
        Platform.OnPlatformLeft -= OnPlaformLeftHandler;
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnInitialObstacles();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnPlaformLeftHandler(Platform platform)
    {
        Debug.Log("PLATFORM LEFT TRIGGERED");

        if (randomZ < (Playercontroller.playerPosZ + 160))
        {
            Debug.Log("RANDOMZ LESS THAN PLATFORM");

            if (PlatformSpawner.bossLevel == false)
            {
                SpawnObstacles();
            }
            else
            {
                randomZ += 16;
            }
        }
    }
}
