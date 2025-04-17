using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    [SerializeField] string tagFilter;
    void OnTriggerEnter(Collider other)
    {
        if (!string.IsNullOrEmpty(tagFilter) && !other.CompareTag(tagFilter))
            return;
        SceneLoadData.isPlayerInCimetery = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (!string.IsNullOrEmpty(tagFilter) && !other.CompareTag(tagFilter))
            return;
        SceneLoadData.isPlayerInCimetery = false;
    }
}
