using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIcontrollerEnd : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI endScoreMesh;
    public AudioSource click;

    private void Start()
    {
        endScoreMesh.text = "Velocity Vortex Your Score Is "+ ScoreTracker.scoreTracker;

        BossController.bossIsInRange = false;
        PlatformSpawner.bossLevel = false;
        PlatformSpawner.bossSpawned = false;
        PlatformSpawner.round2 = false;

        ObstacleSpawner.randomZ = 13;
        SpawnCoins.randomZ2 = 3;
        SpawnPickup.randomZ3 = 24;

        BossHealth.bossHealth = 6;
    }
    public void OnStartClick()
    {
        PlatformSpawner.levelCounter1 += 350;
        PlatformSpawner.levelCounter2 += 600;
        PlatformSpawner.levelCounter3 += 850;

        BossHealth.levelsBeat = 0;

        ScoreTracker.scoreTracker = 0;
        Playercontroller.speedBoost = false;
        Playercontroller.speedBoostTimer = 5;
        Playercontroller.timesTwoBoost = false;
        Playercontroller.timesTwoBoostTimer = 10;
        PlatformSpawner.level2 = false;

        click.Play();

        SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
    }

    public void OnExitClick() 
    { 
        click.Play();
        Application.Quit();
    }
}
