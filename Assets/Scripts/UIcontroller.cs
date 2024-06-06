using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTextMesh;
    [SerializeField] private TextMeshProUGUI bossLevelTextMesh;
    [SerializeField] private TextMeshProUGUI bossInstructionsTextMesh;
    [SerializeField] private TextMeshProUGUI PowerUpTextMesh;
    [SerializeField] private TextMeshProUGUI bossHealthTextMesh;
    [SerializeField] private TextMeshProUGUI bossHealthBarTextMesh;

    public GameObject pausePanel;

    public AudioSource pauseSound;
    public AudioSource gameSound;
    public AudioSource click;

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
        scoreTextMesh.text = "Score " + score; 
    }
    void Start()
    {
        pauseSound.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        scoreTextMesh.text = "Score " + ScoreTracker.scoreTracker;

        if (PlatformSpawner.bossLevel == true)
        {
            bossInstructionsTextMesh.text = "Press The 'SpaceBar' To Speed Up And Knock The Boss";
            bossLevelTextMesh.text = "Boss Level";
            bossHealthTextMesh.text = "Boss Health";

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
            PowerUpTextMesh.text = "Speed Boost " + Playercontroller.speedBoostTimer + " Seconds";
        }

        if (Playercontroller.timesTwoBoost == true)
        {
            PowerUpTextMesh.text = "Coin Multiplier " + Playercontroller.timesTwoBoostTimer + " Seconds";
        }

        if (Playercontroller.timesTwoBoost == false &&  Playercontroller.speedBoost == false)
        {
            PowerUpTextMesh.text = "";
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;

            click.Play();
            gameSound.Pause();
            pauseSound.Play();
        }
    }

    public void OnResumeClick()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;

        click.Play();
        pauseSound.Stop();
        gameSound.Play();
    }

    public void OnEndGameClick()
    {
        click.Play();
        SceneManager.LoadSceneAsync("GameOverScene", LoadSceneMode.Single);
    }
}
