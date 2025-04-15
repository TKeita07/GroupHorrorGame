using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private string sceneName; // Reference to the Start button
    public void StartGame()
    {

        SceneLoadData.hasSeenTutorial = false;
        SceneLoadData.clockStarted = false;
        SceneLoadData.currentTime = 0.0f;
        SceneLoadData.reduceTime = false;
        SceneLoadData.dead = false;
        SceneLoadData.success = false;
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