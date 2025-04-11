using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using System;

public class Clock : MonoBehaviour
{

    public enum ClockChoices { Clock, Timer };

    [SerializeField]
    public ClockChoices dropDown = ClockChoices.Clock;  // this public var should appear as a drop down

    // Durrée de la partie en minutes
    public int TempDeJeux = 5;  

    private TextMeshProUGUI timerText;
    private float timeElapsed;
    private float timefactor;  

    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        timeElapsed = 0f;
        timefactor = 18000 / (TempDeJeux * 60); // 18000 seconds = 5 hours
    }

    void Update()
    {
        if (dropDown == ClockChoices.Timer)
        {
            TimerElapse();
        }
        else if (dropDown == ClockChoices.Clock)
        {
            ClockElapse();
        }
    }
    void TimerElapse() {
        timeElapsed += Time.deltaTime;

        int totalSeconds = Mathf.FloorToInt(timeElapsed);
        int timeleft = (TempDeJeux * 60) - totalSeconds;

        int minutes = (timeleft % 3600) / 60;
        int secondes = timeleft % 60;

        timerText.text = minutes.ToString("00") + ":" + secondes.ToString("00");
    }

    void ClockElapse() {
        timeElapsed += Time.deltaTime* timefactor;

        int totalSeconds = Mathf.FloorToInt(timeElapsed);
        int hours = totalSeconds / 3600;
        int minutes = (totalSeconds % 3600) / 60;

        timerText.text = hours.ToString("00") + ":" + minutes.ToString("00");
    }
}
