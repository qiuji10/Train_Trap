using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCore : MonoBehaviour
{
    public static PlayerCore instance;
    private bool isCrouch, activateDistract, keyE, keyR, keyF;
    public List<string> inventoryName = new List<string>();

    void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    public bool IsCrouch
    {
        get => isCrouch;
        set => isCrouch = value;
    }

    public bool ActivateDistract
    {
        get => activateDistract;
        set => activateDistract = value;
    }

    public bool KeyE
    {
        get => keyE;
        set => keyE = value;
    }

    public bool KeyR
    {
        get => keyR;
        set => keyR = value;
    }

    public bool KeyF
    {
        get => keyF;
        set => keyF = value;
    }

    public bool CheckItem(ref int i, string itemName)
    {
        foreach (string item in inventoryName)
        {
            if (item == itemName)
            {
                return true;
            }
            i++;
        }
        i = 0;
        return false;
    }
}
