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
        if (ScoreTracker.scoreTracker > 99)
        {
            speed = 13;
        }

        if (ScoreTracker.scoreTracker > 199)
        {
            speed = 16;
        }

        if (ScoreTracker.scoreTracker > 349)
        {
            speed = 18;
        }

        if (ScoreTracker.scoreTracker > 499)
        {
            speed = 20;
        }

        if (bossIsInRange == true)
        {
            if (beenHit == false)
            {
                transform.position += new Vector3(Playercontroller.playerPosX * Time.deltaTime, 0, speed * Time.deltaTime);
            }

            if (PlatformSpawner.level2 == false)
            {
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
            else
            {
                if (beenHit == true || Playercontroller.playerPosZ > transform.position.z)
                {
                    transform.position += new Vector3(Playercontroller.playerPosX * Time.deltaTime, 0, 50 * Time.deltaTime);

                    if (transform.position.z >= (Playercontroller.playerPosZ + 20))
                    {
                        beenHit = false;
                    }
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
