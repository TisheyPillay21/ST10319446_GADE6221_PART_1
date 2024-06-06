using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public static int bossHealth = 6;
    public static int levelsBeat = 0;

    private void Update()
    {
        if (bossHealth == 0)
        {
            levelsBeat += 1;
            ScoreTracker.scoreTracker += 10;

            if ((PlatformSpawner.level2 == true) && (ScoreTracker.scoreTracker > PlatformSpawner.levelCounter3))
            {
                PlatformSpawner.level2 = false;

                PlatformSpawner.levelCounter1 += 750;
                PlatformSpawner.levelCounter2 += 750;
                PlatformSpawner.levelCounter3 += 750;
            }

            BossController.bossIsInRange = false;
            PlatformSpawner.bossLevel = false;
            PlatformSpawner.bossSpawned = false;
            BossController.beenHit = false;
            PlatformSpawner.round2 = false;

            Destroy(gameObject);

        }

        if (BossController.bossComeBack == true)
        {
            BossController.bossIsInRange = false;
            PlatformSpawner.bossLevel = false;
            PlatformSpawner.bossSpawned = false;
            BossController.beenHit = false;
        }
    }
    private void OnEnable()
    {
        BossObstacle.OnBossTriggered += OnBossTriggeredHandler;
    }

    private void OnDisable()
    {
        BossObstacle.OnBossTriggered -= OnBossTriggeredHandler;
    }

    private void OnBossTriggeredHandler()
    {
        bossHealth -= 1;
    }
}
