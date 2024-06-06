using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickup : MonoBehaviour
{
    [SerializeField] private GameObject[] pickup;
    [SerializeField] private int initalObstacleCount = 20;

    private Vector3 spawnPosition = Vector3.zero;
    public static int randomZ3 = 24;

    private void SpawnPickups()
    {
        float randomX = Random.Range(-2.3f, 2.3f);

        spawnPosition = new Vector3(randomX, 0, randomZ3);

        randomZ3 += 400;

        int index = Random.Range(0, pickup.Length);

        GameObject newObstacleGameObject = Instantiate(pickup[index], spawnPosition, Quaternion.identity);
        

        Debug.Log("OBSTACLE SPAWNED");
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
        SpawnPickups();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnPlaformLeftHandler(Platform platform)
    {
        Debug.Log("PLATFORM LEFT TRIGGERED");

        if (randomZ3 < (Playercontroller.playerPosZ + 160))
        {
            Debug.Log("RANDOMZ LESS THAN PLATFORM");

            if (PlatformSpawner.bossLevel == false)
            {
                SpawnPickups();
            }
            else
            {
                randomZ3 += 400;
            }
        }
    }
}
