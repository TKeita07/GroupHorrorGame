using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using System;

public class CountDown : MonoBehaviour
{
    // Durrée du timer en secondes
    public int countDownTime = 15;  

    [SerializeField]
    private GameObject countDownObject; // Reference to the timer object in the scene
    [SerializeField]
    private GameObject panelObject;

    private TextMeshProUGUI countDownText;
    private float timeElapsed;
    private bool isCountDownRunning = false;
    private int skipFirstFrames = 5;
    private int framedSkipped = 0;

    void Start()
    {
        countDownText = countDownObject.GetComponent<TextMeshProUGUI>();
        countDownText.text = countDownTime.ToString();
        if (SceneLoadData.hasSeenTutorial){
            panelObject.SetActive(false);
        } else {
            StartTimer();
            SceneLoadData.hasSeenTutorial = true;
        }
        
    }

    void Update()
    {
        if (framedSkipped < skipFirstFrames)
        {
            framedSkipped++;
            
            return;
        }
        if (isCountDownRunning)
        {CountDownCoroutine();}

    }
    private void CountDownCoroutine()
    {

        timeElapsed += Time.unscaledDeltaTime;

        int totalSeconds = Mathf.FloorToInt(timeElapsed);
        int timeleft = countDownTime - totalSeconds;

        countDownText.text = timeleft.ToString();

        if (timeleft <= 0)
        {
            isCountDownRunning = false;
            Time.timeScale = 1;
            panelObject.SetActive(false);
            PlayerPrefs.SetInt("hasSeenTuto", 1); 
            return;
        }

    }

    public void StartTimer()
    {
        isCountDownRunning = true;
        timeElapsed = 0f;
        Time.timeScale = 0;
    }
}
