using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class SceneSwitching : MonoBehaviour, IInteractable
{
    public AudioClip audioClip; // Reference to the die sound clip
    public GameObject audioObject; // Reference to the AudioSource component
    [SerializeField] private string sceneName; // Reference to the Start button
    void IInteractable.Interact(GameObject playerObject)
    {
        StartCoroutine(waiter());
        Time.timeScale = 0; // Reset time scale to normal
    }

    private IEnumerator waiter()
    {
        audioObject.transform.position = transform.position; // Set the position of the audio source to the die's position
        AudioSource audioSource = audioObject.GetComponent<AudioSource>(); // Get the AudioSource component
        audioSource.PlayOneShot(audioClip); // Play the die sound once

        //Wait for 4 seconds
        yield return new WaitForSecondsRealtime(1);
        print("waiter");
        SceneManager.LoadScene(sceneName);
    }
}
