using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickup : MonoBehaviour
{
    [SerializeField] private GameObject[] pickup;
    [SerializeField] private int initalObstacleCount = 20;

    private Vector3 spawnPosition = Vector3.zero;
    public static int randomZ3 = 20;

    private void SpawnPickups()
    {
        float randomX = Random.Range(-2.3f, 2.3f);

        spawnPosition = new Vector3(randomX, 0, randomZ3);

        randomZ3 += 50;

        int index = Random.Range(0, pickup.Length);

        GameObject newObstacleGameObject = Instantiate(pickup[index], spawnPosition, Quaternion.identity);
        

        Debug.Log("OBSTACLE SPAWNED");
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
}
