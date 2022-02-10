using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    private bool isCrouch = false;

    public bool IsCrouch
    {
        get => isCrouch;
        set => isCrouch = value;
    }
}
