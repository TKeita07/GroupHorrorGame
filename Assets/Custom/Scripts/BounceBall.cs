using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class BounceBall : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public RandomInputActions m_inputAction;
    public float up_factor = 3.0f;
    private InputAction m_random2;

    void OnEnable()
    {
        m_inputAction = new RandomInputActions();
        m_random2 = m_inputAction.Random.Random2;
        m_random2.Enable();
    }

    void OnDisable()
    {
        m_random2.Disable();
    }

    void Start()
    {
        // m_inputAction = GetComponent<RandomInputActions>(); 
    }
    
    void Update()
    {
        if (m_random2.WasPressedThisFrame())
        {
            transform.position += up_factor * Vector3.up;
        }
    }
}
