using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pushing : MonoBehaviour
{
    [SerializeField]
    private float forceMagnitude;

    private void Start()
    {
    }

    private void Update()
    {
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var rigidBody = hit.collider.attachedRigidbody;

        if (rigidBody != null)
        {
            var forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();
            
            rigidBody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);

            
        }
    }
}
