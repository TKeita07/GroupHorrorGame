using UnityEngine;

public class PushingObject : MonoBehaviour, IInteractable
{    
    [Range(0.5f, 5f)] public float strength = 1.1f;
    private Rigidbody m_RigidBody;

    void IInteractable.Interact(GameObject playerObject)
    {
        // Calculate push direction based on the player's facing direction, horizontal motion only
        Vector3 facingDirection = playerObject.transform.forward; // Use player's forward direction
        Vector3 pushDir = new Vector3(facingDirection.x, 0, facingDirection.z).normalized;
        m_RigidBody.AddForce(pushDir * strength, ForceMode.Impulse);
        // Implement the interaction logic here
        Debug.Log("Interacting with " + gameObject.name);
    }

    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();

    }

    void Update()
    {

    }

}