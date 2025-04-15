using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectObject : MonoBehaviour, IInteractable
{
    public AudioClip dieSound; // Reference to the die sound clip
    public GameObject audioObject; // Reference to the AudioSource component
    void IInteractable.Interact(GameObject playerObject)
    {
        audioObject.transform.position = transform.position; // Set the position of the audio source to the die's position
        AudioSource audioSource = audioObject.GetComponent<AudioSource>(); // Get the AudioSource component
        audioSource.PlayOneShot(dieSound); // Play the die sound once
        SceneLoadData.reduceTime = true;
        Destroy(this.gameObject);
    }

    void Start()
    {

    }

    void Update()
    { }
        
}
