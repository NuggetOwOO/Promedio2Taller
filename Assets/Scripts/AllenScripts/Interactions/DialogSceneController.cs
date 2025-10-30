using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogSceneController : MonoBehaviour
{
    [System.Serializable]
    public class DialogLine
    {
        [TextArea(2, 5)]
        public string text;
    }

    [Header("UI References")]
    public DialogController dialogController;
    public DialogSetting dialogSetting;
    public GameObject choicePanel;
    public Button choice1Button;
    public Button choice2Button;
    public TMP_Text choice1Text;
    public TMP_Text choice2Text;

    [Header("Dialog Data")]
    public DialogLine[] initialDialog;
    public DialogLine[] choice1Dialog;
    public DialogLine[] choice2Dialog;

    private int currentIndex = 0;
    private DialogLine[] currentDialog;

    private void Start()
    {
        choicePanel.SetActive(false);
        currentDialog = initialDialog;
        ShowNextLine();
    }

    public void OnDialogFinish()
    {
        currentIndex++;
        if (currentIndex < currentDialog.Length)
        {
            ShowNextLine();
        }
        else
        {
            if (currentDialog == initialDialog)
            {
                ShowChoices();
            }
            else
            {
                EndDialogSequence();
            }
        }
    }

    void ShowNextLine()
    {
        dialogController.ShowDialog(this, currentDialog[currentIndex].text, dialogSetting);
    }

    void ShowChoices()
    {
        choicePanel.SetActive(true);
        choice1Text.text = "Help Miku";
        choice2Text.text = "Nor help Miku";

        choice1Button.onClick.RemoveAllListeners();
        choice2Button.onClick.RemoveAllListeners();

        choice1Button.onClick.AddListener(() =>
        {
            choicePanel.SetActive(false);
            currentDialog = choice1Dialog;
            currentIndex = 0;
            ShowNextLine();
        });

        choice2Button.onClick.AddListener(() =>
        {
            choicePanel.SetActive(false);
            currentDialog = choice2Dialog;
            currentIndex = 0;
            ShowNextLine();
        });
    }

    void EndDialogSequence()
    {
        Debug.Log("Fin del diálogo.");
    }
}