using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

[RequireComponent(typeof(AudioSource))]
public class PlayAudio : MonoBehaviour
{
    private AudioSource m_AudioSource;
    public RandomInputActions m_inputAction;
    private InputAction m_random1;
    private InputAction m_random2;

    void OnEnable()
    {
        m_inputAction = new RandomInputActions();
        m_random1 = m_inputAction.Random.Random1;
        m_random1.Enable();
    }

    void OnDisable()
    {
        m_random1.Disable();
    }

    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        // m_inputAction = GetComponent<RandomInputActions>(); 
    }
    
    void Update()
    {
        if (m_random1.WasPressedThisFrame())
        {
            print("Cutting wood");
            m_AudioSource.Play();
        }
    }

}
