using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogSetting", menuName = "Game/DialogSetting")]
public class DialogSetting : ScriptableObject
{
    public float charactersPerSecond;
    public float turboCharactersPerSecond;
    public Sprite character1Default;
    public Sprite character2Default;
    public List<Dialog> dialogs;
    public float dialogEndDelay = 1f;
}
