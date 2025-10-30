using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogSetting", menuName = "Dialog System/Dialog Setting")]
public class DialogSetting : ScriptableObject
{
    [Header("Speed Settings")]
    public float charactersPerSecond = 30f;
    public float turboCharactersPerSecond = 100f;

    [Header("Timing")]
    public float dialogEndDelay = 1f;
}
