using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private string sceneName; // Reference to the Start button
    public void StartGame()
    {
        // Load the game scene (assuming it's named "GameScene")
        SceneManager.LoadScene(sceneName);
    }
    public void Start(){
        
    }
}