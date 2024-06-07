using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class FirebaseUser
{
    public string name;
    public float score;
    public float levelsPassed;

    public FirebaseUser()
    {
        name = UIController.name;
        score = ScoreTracker.scoreTracker;
        levelsPassed = BossHealth.levelsBeat;
    }
}
