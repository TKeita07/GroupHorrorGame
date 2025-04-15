using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using StarterAssets;

public class Die : MonoBehaviour
{
    public bool isPlayer; // Reference to the die sound clip
    public AudioClip dieSound; // Reference to the die sound clip
    public GameObject audioObject; // Reference to the AudioSource component

    void Start()
    {
       
    }

    public void die(){
        PlayDieSound();
        Destroy(this.gameObject);
        if(isPlayer){
            SceneLoadData.dead = true;
            // Destroy(GameObject.Find("PlayerFollowCamera")); // Destroy the parent object (the player)
        }

    }
    public void PlayDieSound()
    {
        audioObject.transform.position = transform.position; // Set the position of the audio source to the die's position
        AudioSource audioSource = audioObject.GetComponent<AudioSource>(); // Get the AudioSource component
        audioSource.PlayOneShot(dieSound); // Play the die sound once
    }
}