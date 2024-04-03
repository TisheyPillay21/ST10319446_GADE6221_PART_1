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
        scoreTextMesh.text = "Tokens " + score; 
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreTextMesh.text = "Tokens " + ScoreTracker.scoreTracker;
    }
}
