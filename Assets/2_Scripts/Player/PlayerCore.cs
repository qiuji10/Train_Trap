using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    private bool isCrouch = false;
    [SerializeField]
    private bool isInteracted = false;

    public bool IsCrouch
    {
        get => isCrouch;
        set => isCrouch = value;
    }

    public bool IsInteracted
    {
        get => isInteracted;
        set => isInteracted = value;
    }

}
