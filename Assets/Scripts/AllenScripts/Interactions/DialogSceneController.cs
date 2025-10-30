using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DialogSceneController : MonoBehaviour
{
    private PlayerMovement playerMovement;

    [Header("UI Root")]
    public GameObject dialogCanvas;

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
    public Button skipButton;
    public Image character1;
    public Image character2;

    [Header("Dialog Data")]
    public DialogLine[] initialDialog;
    public DialogLine[] choice1Dialog;
    public DialogLine[] choice2Dialog;

    private int currentIndex = 0;
    private DialogLine[] currentDialog;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private IEnumerator StartDialogWithDelay()
    {
        yield return new WaitForEndOfFrame();
        ShowNextLine();
    }

    private void OnSkip()
    {
        if (dialogController != null)
        {
            dialogController.SkipCurrentLine();
        }
    }

    public void OnDialogFinish()
    {
        currentIndex++;

        if (currentDialog != null && currentIndex < currentDialog.Length)
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

    public void StartDialog()
    {
        gameObject.SetActive(true);

        if (playerMovement != null)
            playerMovement.CanMove = false;

        if (dialogSetting != null)
        {
            if (dialogSetting.character1Default != null)
                character1.sprite = dialogSetting.character1Default;

            if (dialogSetting.character2Default != null)
                character2.sprite = dialogSetting.character2Default;
        }

        if (skipButton != null)
            skipButton.onClick.AddListener(OnSkip);

        currentDialog = initialDialog;
        currentIndex = 0;
        StartCoroutine(StartDialogWithDelay());
    }

    private void ShowNextLine()
    {
        if (dialogController != null && currentDialog != null && currentDialog.Length > 0)
            dialogController.ShowDialog(this, currentDialog[currentIndex].text, dialogSetting);
        else
            Debug.LogWarning("DialogController o currentDialog no asignado correctamente.");
    }

    private void ShowChoices()
    {
        choicePanel.SetActive(true);
        choice1Text.text = "Help Miku";
        choice2Text.text = "Not help Miku";

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

    private void EndDialogSequence()
    {
        Debug.Log("End of dialog sequence.");

        if (playerMovement != null)
            playerMovement.CanMove = true;

        if (dialogCanvas != null)
            dialogCanvas.SetActive(false);

        gameObject.SetActive(false);
    }
}