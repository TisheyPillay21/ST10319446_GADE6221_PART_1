using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Obstacle : MonoBehaviour
{
    public delegate void ObstacleTriggeredAction();
    public static event ObstacleTriggeredAction OnObstacleTriggered;

    public static bool isDead = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(message : "Hit obstacle");

        if (!other.CompareTag("Player"))
            return;

        if (Playercontroller.speedBoost == false)
        {
            Time.timeScale = 0;
            isDead = true;
        }
        else
        {
            ScoreTracker.scoreTracker += 3;
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (transform.position.z < (Playercontroller.playerPosZ - 10))
        {
            Destroy(gameObject);
        }
    }
}
