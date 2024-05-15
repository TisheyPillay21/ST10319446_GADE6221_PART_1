using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random; 

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] platformPrefabs;
    [SerializeField] private GameObject initialPlatform;
    [SerializeField] private GameObject bossPlatform;
    [SerializeField] private GameObject boss;
    [SerializeField] private int initalPlatformCount = 20;

    public static bool bossLevel = false;
    public static bool bossSpawned = false;
    public static bool round2 = false;
    public static bool mainPlatform = false;

    public static int counter = 0;

    private int i = 1;

    private Vector3 spawnPosition = Vector3.zero;

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log(message: "Initial Spawned");
        SpawnInitialPlatforms();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ScoreTracker.scoreTracker == 100)
        {
            bossLevel = true;
            i = 1;
        }

        if ((ScoreTracker.scoreTracker >= 350) && (BossHealth.bossHealth > 0))
        {
            round2 = true;
            BossController.bossComeBack = false;

            bossLevel = true;
            i = 1;
        }

        if (ScoreTracker.scoreTracker == 350)
        {
            bossSpawned = false;
        }
    }

    private void SpawnInitialBossPlatform()
    {
        GameObject newPlatformGameObject = Instantiate(bossPlatform, spawnPosition, Quaternion.identity);

        Platform platform = newPlatformGameObject.GetComponent<Platform>();

        spawnPosition = platform.ConnectorPosition;
    }

    private void SpawnInitialPlatforms()
    {
        GameObject newPlatformGameObject = Instantiate(initialPlatform, spawnPosition, Quaternion.identity);


        Platform platform = newPlatformGameObject.GetComponent<Platform>();
        spawnPosition = platform.ConnectorPosition;

        for (int i = 0; i < initalPlatformCount; i++)
        {
            SpawnPlatform();
        }
    }

    private void OnEnable()
    {
        Platform.OnPlatformLeft += OnPlaformLeftHandler;
    }

    private void OnDisable()
    {
        Platform.OnPlatformLeft -= OnPlaformLeftHandler;
    }

    private void SpawnPlatform()
    {
        if (bossLevel == false)
        {
            int index = Random.Range(0, platformPrefabs.Length);
            GameObject newPlatformGameObject = Instantiate(platformPrefabs[index], spawnPosition, Quaternion.identity);


            Platform platform = newPlatformGameObject.GetComponent<Platform>();
            spawnPosition = platform.ConnectorPosition;

            
        }

        

        if (bossLevel == true)
        {
            if (i == 1)
            {
                SpawnInitialBossPlatform();
                i++;
                Debug.Log("INITIAL BOSS PLATFORM SPAWNED");
            }

            GameObject newPlatformGameObject = Instantiate(bossPlatform, spawnPosition, Quaternion.identity);

            Platform platform = newPlatformGameObject.GetComponent<Platform>();
            
            spawnPosition = platform.ConnectorPosition;

            Debug.Log("BOSS PLATFORM SPAWNED");

            if (bossSpawned == false)
            {
                Instantiate(boss, new Vector3(spawnPosition.x, spawnPosition.y + 3, spawnPosition.z), Quaternion.identity);
                bossSpawned = true;
                Debug.Log("BOSS SPAWNED");
            }
        }
    }

    private void OnPlaformLeftHandler(Platform platform)
    {
        Debug.Log(message: "PLATFORM DESTROYED");
        Destroy(platform.gameObject, 3);

        ScoreTracker.scoreTracker = ScoreTracker.scoreTracker + 1;

        Debug.Log(message: "PLATFORM SPAWNED");
        SpawnPlatform();
        mainPlatform = true;

        if (ObstacleSpawner.obstacleSpawned == true)
        {
            mainPlatform = false;
            ObstacleSpawner.obstacleSpawned = false;
        }
        
        



        ObstacleSpawner.randomZ += 8;    
    }
}
