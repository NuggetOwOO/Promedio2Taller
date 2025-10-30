using UnityEngine;

[CreateAssetMenu(fileName = "DialogSetting", menuName = "Dialog/Setting")]
public class DialogSetting : ScriptableObject
{
    [Header("Dialog Speed Settings")]
    public float charactersPerSecond = 30f;
    public float turboCharactersPerSecond = 100f;
    public float dialogEndDelay = 0.5f;

    [Header("Character Portraits")]
    public Sprite character1Default;
    public Sprite character2Default;
}