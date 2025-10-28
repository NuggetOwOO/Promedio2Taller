using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour
{
    [Header("Scene name")]
    [SerializeField] private string sceneName;

    public void ChangeScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log("Scene not asigned");
        }
    }
    public void QuitGame()
    {
        Debug.Log("closing game");
        Application.Quit();
    }
}
