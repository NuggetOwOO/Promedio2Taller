using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public GameObject dialogCanvas;
    public DialogSceneController dialogScene;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogCanvas.SetActive(true);
            dialogScene.StartDialog();
            gameObject.SetActive(false);
        }
    }
}
