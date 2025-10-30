using UnityEngine;
using TMPro;
using System.Collections;

public class DialogController : MonoBehaviour
{
    private TextMeshProUGUI dialogUIText;
    private string currentDialog = "";
    private DialogSceneController sceneController;
    private float currentCharactersPerSecond;
    private DialogSetting dialogSetting;
    private bool isTurbo;
    private Coroutine typingCoroutine;

    private void Awake()
    {
        dialogUIText = GetComponent<TextMeshProUGUI>();
    }

    public void ShowDialog(DialogSceneController sceneController, string dialog, DialogSetting dialogSetting)
    {
        if (!gameObject.activeInHierarchy)
            gameObject.SetActive(true);

        currentCharactersPerSecond = dialogSetting.charactersPerSecond;
        this.dialogSetting = dialogSetting;
        this.sceneController = sceneController;
        currentDialog = dialog;

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(ShowText());
    }

    private IEnumerator ShowText()
    {
        dialogUIText.text = "";
        int i = 0;

        while (i <= currentDialog.Length)
        {
            dialogUIText.text = currentDialog.Substring(0, i);

            if (i < currentDialog.Length)
                dialogUIText.text += $"<color=#00000000>{currentDialog.Substring(i)}</color>";

            i++;
            yield return new WaitForSeconds(1f / currentCharactersPerSecond);
        }

        if (!isTurbo)
            yield return new WaitForSeconds(dialogSetting.dialogEndDelay);

        EndDialog();
    }

    private void EndDialog()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = null;

        if (sceneController != null)
            sceneController.OnDialogFinish();
    }

    public void SkipCurrentLine()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }

        // Mostrar toda la línea 
        dialogUIText.text = currentDialog;

        EndDialog();
    }

    private void Update()
    {
        if (dialogSetting == null) return;

        if (Input.GetKey(KeyCode.Space))
        {
            isTurbo = true;
            currentCharactersPerSecond = dialogSetting.turboCharactersPerSecond;
        }
        else
        {
            isTurbo = false;
            currentCharactersPerSecond = dialogSetting.charactersPerSecond;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndDialog();
        }
    }
}
