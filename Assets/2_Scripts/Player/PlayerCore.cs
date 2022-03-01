using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCore : MonoBehaviour
{
    public static PlayerCore instance;
    private bool isCrouch = false;
    private bool activateDistract = false;
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
        return false;
    }
}
