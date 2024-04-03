using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIcontrollerEnd : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI endScoreMesh;

    private void Start()
    {
        endScoreMesh.text = "VELOCITY VORTEX Your Score Is "+ ScoreTracker.scoreTracker;
    }
    public void OnStartClick()
    {
        ScoreTracker.scoreTracker = 0;
        SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
    }

    public void OnExitClick() 
    { 
        Application.Quit();
    }
}
