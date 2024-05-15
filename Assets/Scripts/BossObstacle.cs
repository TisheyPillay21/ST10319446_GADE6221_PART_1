using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossObstacle : MonoBehaviour
{
    public delegate void BossTriggeredAction();
    public static event BossTriggeredAction OnBossTriggered;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(message: "Hit obstacle");

        if (!other.CompareTag("Player"))
            return;


        OnBossTriggered?.Invoke();
    }
}
