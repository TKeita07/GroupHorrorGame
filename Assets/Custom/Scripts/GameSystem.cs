
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using System;
using UnityEngine.AI;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class GameSystem : MonoBehaviour
{
    public GameObject gameOverPanel; // Reference to the game over panel object
    public GameObject successPanel;
    public GameObject nunController; // Reference to the nun controller object
    public AudioSource doorAudioSource ; // Reference to the death sound script
    public AudioClip deathSound; // Reference to the death sound object
    public AudioClip successSound;
    public AudioMixer mixer;

    public Transform spawnPosition; // Reference to the spawn position of the nun
    private bool isCountDownRunning = false;

    private float timeElapsed;



    private AudioSource m_audioSource ; // Reference to the death sound script
    private bool playOnce = true; // Flag to ensure the sound plays only once
    private bool timerPlayOnce = false;
    private int countDownTime = 15;  

    


    void Start()
    {
        gameOverPanel.SetActive(false); // Hide the game over panel at the start
        m_audioSource = GetComponent<AudioSource>(); // Get the AudioSource component from the death sound object

        if (SceneLoadData.delayNunSpawn)
        {
            nunController.SetActive(false);
            StartTimer();
        }
        hideDeadKids(); // Hide the dead kids at the start
    }

    void Update()
    {
        if (SceneLoadData.dead)
        {
            Cursor.lockState = CursorLockMode.None;
            ShowGameOverPanel();
            if (playOnce){
                
                muteSounds();
                m_audioSource.PlayOneShot(deathSound); // Play the death sound
                playOnce = false;
            }
        }
        if (SceneLoadData.success)
        {
            Cursor.lockState = CursorLockMode.None;
            successPanel.SetActive(true);
            if (playOnce){
                
                muteSounds();
                m_audioSource.PlayOneShot(successSound); // Play the death sound
                playOnce = false;
            }
        }

        if (isCountDownRunning)
        {CountDown();}

    }

    private void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true); // Show the game over panel
        // Time.timeScale = 0f; // Pause the game
    }

    private void CountDown()
    {
        
        timeElapsed += Time.deltaTime; // Increment the elapsed time

        int totalSeconds = Mathf.FloorToInt(timeElapsed);
        int timeleft = countDownTime - totalSeconds;


        if (!timerPlayOnce && timeleft <= 2)
        {
            timerPlayOnce = true;
            doorAudioSource.Play();
        }

        if (timeleft <= 0)
        {
            isCountDownRunning = false;
            nunController.transform.position = spawnPosition.position; // Spawn the nun at the specified position
            nunController.SetActive(true);
            return;
        }

    }

    public void StartTimer()
    {
        timerPlayOnce = false;
        isCountDownRunning = true;
        timeElapsed = 0f;
        countDownTime = UnityEngine.Random.Range(8, 15); 
    }

    private void muteSounds()
    {
        float value;
        mixer.GetFloat("FX_Volume", out value);
        SceneLoadData.FX_Volume = value;
        mixer.SetFloat("FX_Volume", -80.00f);

        mixer.GetFloat("Music_Volume", out value);
        SceneLoadData.Music_Volume = value;
        mixer.SetFloat("Music_Volume", -80.00f);

    }

    private void hideDeadKids()
    {
        foreach (string deadKid in SceneLoadData.deadKids)
        {
            GameObject deadKidObject = GameObject.Find(deadKid);
            if (deadKidObject != null)
            {
                deadKidObject.SetActive(false); // Hide the dead kid object
            }
        }
    }
}