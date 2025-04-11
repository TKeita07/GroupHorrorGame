
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using System;

public class GameSystem : MonoBehaviour
{
    public GameObject gameOverPanel; // Reference to the game over panel object
    public GameObject player; // Reference to the player object

    void Start()
    {
        gameOverPanel.SetActive(false); // Hide the game over panel at the start
    }

    void Update()
    {
        if (SceneLoadData.dead)
        {
            ShowGameOverPanel();
        }
    }

    private void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true); // Show the game over panel
        // Time.timeScale = 0f; // Pause the game
    }
}