using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIcontrollerEnd : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI endScoreMesh;

    private void Start()
    {
        endScoreMesh.text = "VELOCITY VORTEX Your Score Is "+ ScoreTracker.scoreTracker;

        BossController.bossIsInRange = false;
        PlatformSpawner.bossLevel = false;
        PlatformSpawner.bossSpawned = false;
        PlatformSpawner.round2 = false;

        ObstacleSpawner.randomZ = 13;
        SpawnCoins.randomZ2 = 3;
        SpawnPickup.randomZ3 = 20;

        BossHealth.bossHealth = 6;
    }
    public void OnStartClick()
    {
        ScoreTracker.scoreTracker = 0;
        Playercontroller.speedBoost = false;
        Playercontroller.timesTwoBoost = false;
        SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
    }

    public void OnExitClick() 
    { 
        Application.Quit();
    }
}
