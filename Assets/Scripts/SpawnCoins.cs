using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    [SerializeField] private GameObject tokens;
    [SerializeField] private int initalObstacleCount = 20;

    private Vector3 spawnPosition = Vector3.zero;
    public static int randomZ2 = 3;

    private void SpawnInitialTokens()
    {
        for (int i = 0; i < initalObstacleCount; i++)
        {
            SpawnTokens();
        }
    }

    private void SpawnTokens()
    {
        float randomX = Random.Range(-2.3f, 2.3f);

        spawnPosition = new Vector3(randomX, 0, randomZ2);

        randomZ2 += 8;

        GameObject newCoinGameObject = Instantiate(tokens, spawnPosition, Quaternion.identity);
        

        Debug.Log("OBSTACLE SPAWNED");
        
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnInitialTokens();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTokens();
    }
}
