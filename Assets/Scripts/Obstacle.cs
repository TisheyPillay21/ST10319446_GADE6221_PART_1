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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(message : "Hit obstacle");

        if (!other.CompareTag("Player"))
            return;

        
        SceneManager.LoadSceneAsync("GameOverScene", LoadSceneMode.Single);
    }
}
