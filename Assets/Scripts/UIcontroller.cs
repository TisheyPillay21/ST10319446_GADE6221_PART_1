using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTextMesh;
    [SerializeField] private TextMeshProUGUI bossLevelTextMesh;
    [SerializeField] private TextMeshProUGUI bossInstructionsTextMesh;
    [SerializeField] private TextMeshProUGUI PowerUpTextMesh;
    [SerializeField] private TextMeshProUGUI bossHealthTextMesh;
    [SerializeField] private TextMeshProUGUI bossHealthBarTextMesh;

    private void OnEnable()
    {
        GameManager.OnScoreUpdate += OnScoreUpdatedHandler; 
    }

    private void OnDisable()
    {
        GameManager.OnScoreUpdate -= OnScoreUpdatedHandler; 
    }

    private void OnScoreUpdatedHandler(int score)
    {
        Debug.Log(message: "UI is now aware of the score update");
        scoreTextMesh.text = "SCORE " + score; 
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreTextMesh.text = "SCORE " + ScoreTracker.scoreTracker;

        if (PlatformSpawner.bossLevel == true)
        {
            bossInstructionsTextMesh.text = "Press The 'SpaceBar' To Speed Up And Knock The Boss";
            bossLevelTextMesh.text = "BOSS LEVEL";
            bossHealthTextMesh.text = "BOSS HEALTH";

            if (BossHealth.bossHealth == 6)
            {
                bossHealthBarTextMesh.text = "======";
            }

            if (BossHealth.bossHealth == 5)
            {
                bossHealthBarTextMesh.text = "=====";
            }

            if (BossHealth.bossHealth == 4)
            {
                bossHealthBarTextMesh.text = "====";
            }

            if (BossHealth.bossHealth == 3)
            {
                bossHealthBarTextMesh.text = "===";
            }

            if (BossHealth.bossHealth == 2)
            {
                bossHealthBarTextMesh.text = "==";
            }

            if (BossHealth.bossHealth == 1)
            {
                bossHealthBarTextMesh.text = "=";
            }
        }
        else
        {
            bossHealthBarTextMesh.text = "";
            bossHealthTextMesh.text = "";
            bossInstructionsTextMesh.text = "";
            bossLevelTextMesh.text = "";
        }

        if (Playercontroller.speedBoost == true)
        {
            PowerUpTextMesh.text = "SPEED BOOST " + Playercontroller.speedBoostTimer + " SECONDS";
        }
        else
        {
            PowerUpTextMesh.text = "";
        }

        if (Playercontroller.timesTwoBoost == true)
        {
            PowerUpTextMesh.text = "MULTIPLIER BOOST " + Playercontroller.timesTwoBoostTimer + " SECONDS";
        }
        else
        {
            PowerUpTextMesh.text = "";
        }
    }
}
