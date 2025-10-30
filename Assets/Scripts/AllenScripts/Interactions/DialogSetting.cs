using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogSetting", menuName = "Game/DialogSetting")]
public class DialogSetting : ScriptableObject
{
    public float charactersPerSecond = 20f;
    public float turboCharactersPerSecond = 100f;
    public Sprite character1Default;
    public Sprite character2Default;
    public List<Dialog> dialogs;
    public float dialogEndDelay = 1f;
}
