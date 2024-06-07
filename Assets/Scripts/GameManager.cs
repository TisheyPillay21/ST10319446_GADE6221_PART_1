using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

//How we make the singleton
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public delegate void ScoreUpdatedAction(int score);
   
    public static event ScoreUpdatedAction OnScoreUpdate;

    

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        
        Instance = this;
    }

    private void OnEnable()
    {
        Pickup.OnPickupTriggered += OnPickupTriggered;
    }

    private void OnDisable()
    {
        Pickup.OnPickupTriggered -= OnPickupTriggered;
    }

    private void OnPickupTriggered()
    {
        if (Playercontroller.timesTwoBoost == true)
        {
            ScoreTracker.scoreTracker ++;
        }
        ScoreTracker.scoreTracker++;
        Debug.Log("pickup triggered");
        OnScoreUpdate?.Invoke(ScoreTracker.scoreTracker);
    }

    public void SaveValues()
    {
        //PlayerPrefs.SetFloat("Name");
        PlayerPrefs.SetFloat("Levels Passed", BossHealth.levelsBeat);
        PlayerPrefs.SetFloat("Score", ScoreTracker.scoreTracker);
    }
}
