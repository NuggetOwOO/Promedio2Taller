using UnityEngine;
using UnityEngine.UI;

public class DialogSceneController : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Image character1;
    [SerializeField] private Image character2;
    [SerializeField] private DialogController dialogController;
    [SerializeField] private Button skipButton;

    [Header("Dialog Settings")]
    [SerializeField] private DialogSetting dialogSetting;


    private int currentDialogIndex = 0;

    private void Start()
    {
        character1.sprite = dialogSetting.character1Default;
        character2.sprite = dialogSetting.character2Default;
        ShowDialog();
        skipButton.onClick.AddListener(OnSkip);
    }

    private void OnSkip()
    {
        dialogController.SkipDialog();
        currentDialogIndex = dialogSetting.dialogs.Count;
        Destroy(gameObject);
    }

    public void OnDialogFinish()
    {
        currentDialogIndex++;
        if (currentDialogIndex < dialogSetting.dialogs.Count)
        {
            ShowDialog();
        }
    }

    private void ShowDialog()
    {
        Dialog currentDialog = dialogSetting.dialogs[currentDialogIndex];
        if (currentDialog.characterID == 1)
        {
            character1.color = Color.white;
            character2.color = new Color(0.4f, 0.4f, 0.4f);
            character1.sprite = currentDialog.characterSprite;
        }
        else if (currentDialog.characterID == 2)
        {
            character1.color = new Color(0.4f, 0.4f, 0.4f);
            character2.color = Color.white;
            character2.sprite = currentDialog.characterSprite;
        }

        dialogController.ShowDialog(this, currentDialog.dialogText, dialogSetting);
    }

}
