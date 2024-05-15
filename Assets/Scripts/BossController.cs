using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private float speed = 13;

    public static bool bossIsInRange = false;
    public static bool beenHit = false;
    public static bool bossComeBack = false;

    // Update is called once per frame
    void Update()
    {
        if (ScoreTracker.scoreTracker == 100)
        {
            speed = 13;
        }

        if (ScoreTracker.scoreTracker == 200)
        {
            speed = 17;
        }

        if (ScoreTracker.scoreTracker == 350)
        {
            speed = 19;
        }

        if (ScoreTracker.scoreTracker == 500)
        {
            speed = 21;
        }

        if (bossIsInRange == true)
        {
            if (beenHit == false)
            {
                transform.position += new Vector3(Playercontroller.playerPosX * Time.deltaTime, 0, speed * Time.deltaTime);
            }

            if (beenHit == true || Playercontroller.playerPosZ > transform.position.z)
            {
                if ((BossHealth.bossHealth == 3) && (ScoreTracker.scoreTracker < 350))
                {
                    transform.position += new Vector3(Playercontroller.playerPosX * Time.deltaTime, 0, 50 * Time.deltaTime);
                    Destroy(gameObject, 3f);
                    Debug.Log("BOSS DESTROYED");

                    PlatformSpawner.bossLevel = false;
                }
                else
                {
                    transform.position += new Vector3(Playercontroller.playerPosX * Time.deltaTime, 0, 50 * Time.deltaTime);

                    if (transform.position.z >= (Playercontroller.playerPosZ + 20))
                    {
                        beenHit = false;
                    }
                }

                if ((BossHealth.bossHealth == 3) && (PlatformSpawner.bossLevel = false))
                {
                    bossComeBack = true;
                }
            }
        }
    }

    private void OnEnable()
    {
        BossPlatform.OnPlatformEnter += OnPlatformEnterHandler;
        BossObstacle.OnBossTriggered += OnBossTriggeredHandler;
    }

    private void OnDisable()
    {
        BossPlatform.OnPlatformEnter -= OnPlatformEnterHandler;
        BossObstacle.OnBossTriggered -= OnBossTriggeredHandler;
    }

    private void OnPlatformEnterHandler(BossPlatform platform)
    {
        bossIsInRange = true;
    }

    private void OnBossTriggeredHandler()
    {
        beenHit = true;
    }
}
