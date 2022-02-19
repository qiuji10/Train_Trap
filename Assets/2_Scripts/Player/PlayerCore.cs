using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCore : MonoBehaviour
{
    public static PlayerCore instance;
    private bool isCrouch = false;
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

    public void deleteArray(int i)
    {
        
    }
}
