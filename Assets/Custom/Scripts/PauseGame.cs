using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenu; // Assign your pause menu UI in the inspector
    private bool isPaused = false;
    void Start()
    {
        pauseMenu.SetActive(false); // Hide the pause menu at the start
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f; // Freeze the game
        pauseMenu.SetActive(true); // Show pause menu
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Resume the game
        pauseMenu.SetActive(false); // Hide pause menu
    }
}