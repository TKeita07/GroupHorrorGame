using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitching : MonoBehaviour, IInteractable
{
    [SerializeField] private string sceneName; // Reference to the Start button
    void IInteractable.Interact(GameObject playerObject)
    {
        SceneManager.LoadScene(sceneName);
    }
}
