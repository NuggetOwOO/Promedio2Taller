using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [Header("Reference to the Dialog Scene Controller")]
    [SerializeField] private DialogSceneController dialogSceneController;

    private bool hasActivated = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasActivated && other.CompareTag("Player"))
        {
            hasActivated = true;
            dialogSceneController.gameObject.SetActive(true);
        }
    }
}
