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

    private void Awake()
    {
        dialogUIText = GetComponent<TextMeshProUGUI>();
    }

    public void ShowDialog(DialogSceneController sceneController, string dialog, DialogSetting dialogSetting)
    {
        currentCharactersPerSecond = dialogSetting.charactersPerSecond;
        this.dialogSetting = dialogSetting;
        this.sceneController = sceneController;
        currentDialog = dialog;
        StopAllCoroutines();
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        int i = 0;
        while (i <= currentDialog.Length)
        {
            dialogUIText.text = string.Empty;
            dialogUIText.text = currentDialog.Substring(0, i);
            if (i < currentDialog.Length)
            {
                dialogUIText.text += $"<color=#0000>{currentDialog.Substring(i)}</color>";
            }
            i++;
            yield return new WaitForSeconds(1 / currentCharactersPerSecond);
        }
        if (!isTurbo)
        {
            yield return new WaitForSeconds(dialogSetting.dialogEndDelay);
        }
        EndDialog();
    }

    private void EndDialog()
    {
        StopAllCoroutines();
        if (sceneController != null)
        {
            sceneController.OnDialogFinish();
        }
    }

    public void SkipDialog()
    {
        StopAllCoroutines();
        dialogUIText.text = "";
    }

    private void Update()
    {
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