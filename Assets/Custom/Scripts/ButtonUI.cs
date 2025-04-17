using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private string sceneName; // Reference to the Start button
    [SerializeField] private AudioMixer mixer;
    public void StartGame()
    {
        ResetDefaultValues();
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

    public void ResetDefaultValues()
    {
        SceneLoadData.hasSeenTutorial = false;
        SceneLoadData.clockStarted = false;
        SceneLoadData.timeLeft = 0.0f;
        SceneLoadData.reduceTime = false;
        SceneLoadData.dead = false;
        SceneLoadData.success = false;
        SceneLoadData.delayNunSpawn = false;
        SceneLoadData.isPlayerInCimetery = false;
        SceneLoadData.deadKids = new List<string>();

        mixer.SetFloat("FX_Volume", SceneLoadData.FX_Volume);
        mixer.SetFloat("Music_Volume", SceneLoadData.Music_Volume);
    }
}