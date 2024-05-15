using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public static int bossHealth = 6;

    private void Update()
    {
        if (bossHealth == 0)
        {
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
