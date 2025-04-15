
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using System;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class GameSystem : MonoBehaviour
{
    public GameObject gameOverPanel; // Reference to the game over panel object
    public GameObject successPanel;
    public AudioClip deathSound; // Reference to the death sound object
    public AudioClip successSound;
    public AudioMixer mixer;
    private AudioSource m_audioSource ; // Reference to the death sound script
    private bool playOnce = true; // Flag to ensure the sound plays only once
    void Start()
    {
        gameOverPanel.SetActive(false); // Hide the game over panel at the start
        m_audioSource = GetComponent<AudioSource>(); // Get the AudioSource component from the death sound object
    }

    void Update()
    {
        if (SceneLoadData.dead)
        {
            Cursor.lockState = CursorLockMode.None;
            ShowGameOverPanel();
            mixer.SetFloat("FX_Volume", -80.00f);
            mixer.SetFloat("Ambiance_Volume", -80.00f);
            mixer.SetFloat("NUN_Volume", -80.00f);
            if (playOnce){
                
                m_audioSource.PlayOneShot(deathSound); // Play the death sound
                playOnce = false;
            }
        }
        if (SceneLoadData.success)
        {
            Cursor.lockState = CursorLockMode.None;
            successPanel.SetActive(true);
            mixer.SetFloat("FX_Volume", -80.00f);
            mixer.SetFloat("Ambiance_Volume", -80.00f);
            mixer.SetFloat("NUN_Volume", -80.00f);
            if (playOnce){
                
                m_audioSource.PlayOneShot(successSound); // Play the death sound
                playOnce = false;
            }
        }
    }

    private void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true); // Show the game over panel
        // Time.timeScale = 0f; // Pause the game
    }
}