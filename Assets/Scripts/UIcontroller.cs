using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Proyecto26;
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
    public GameObject savePanel;

    public static string name;
    public TMP_InputField saveName;

    public AudioSource pauseSound;
    public AudioSource gameSound;
    public AudioSource click;

    public void Awake()
    {
        
    }

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
        //savePanel.SetActive(false);
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

        if (Obstacle.isDead == true)
        {
            savePanel.SetActive(true); 
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

    public void OnSaveClick()
    {
        savePanel.SetActive(false);

        name = saveName.text;

        FirebaseUser firebaseUser = new FirebaseUser();

        RestClient.Put("https://gamebase-46691-default-rtdb.firebaseio.com/" + name + ".json", firebaseUser);

        SceneManager.LoadSceneAsync("GameOverScene", LoadSceneMode.Single);
    }

    public void OnCancelClick()
    {
        savePanel.SetActive(false);
        SceneManager.LoadSceneAsync("GameOverScene", LoadSceneMode.Single);
    }
}
