using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

public class ResetValuies : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {  
        ResetDefaultValues();
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
