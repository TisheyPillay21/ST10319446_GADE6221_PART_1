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
    [SerializeField] private int initalPlatformCount = 20;

    private Vector3 spawnPosition = Vector3.zero;
    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log(message: "Initial Spawned");
        SpawnInitialPlatforms();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        int index = Random.Range(0, platformPrefabs.Length);
        GameObject newPlatformGameObject = Instantiate(platformPrefabs[index], spawnPosition, Quaternion.identity);


        Platform platform = newPlatformGameObject.GetComponent<Platform>();
        spawnPosition = platform.ConnectorPosition;
    }

    private void OnPlaformLeftHandler(Platform platform)
    {
        Debug.Log(message: "PLATFORM DESTROYED");
        Destroy(platform.gameObject, 3);

        ScoreTracker.scoreTracker = ScoreTracker.scoreTracker + 1;

        Debug.Log(message: "PLATFORM SPAWNED");
        SpawnPlatform();
    }
}
