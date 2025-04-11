using UnityEngine;

interface IInteractable {
    public void Interact(GameObject playerObject);
}

public class Interactor : MonoBehaviour
{    
    [SerializeField]
    private GameObject crossObject;
    
    [SerializeField]
    private GameObject playerObject;

    private bool isInteractable = false;
    public Transform InteractorSource;
    public float InteractRange;
    void Start()
    {

    }

    void Update()
    {
        isInteractable = false;
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                isInteractable = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactObj.Interact(playerObject);
                }
                
            }
        }

        if (isInteractable)
        {
            crossObject.SetActive(true); 
        }
        else
        {
            crossObject.SetActive(false); 
        }
    }
}