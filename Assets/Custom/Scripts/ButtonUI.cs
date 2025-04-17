using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private string sceneName; // Reference to the Start button
    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        ChangeScene();
    }

    public void ChangeScene()
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }
    public void Start(){
        
    }


}