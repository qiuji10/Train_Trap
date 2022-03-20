using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerCore : MonoBehaviour
{
    public static PlayerCore instance;
    
    private bool isCrouch, activateDistract, keyE, keyR, keyF, clueUpdated = true;
    public List<string> inventoryName = new List<string>();
    public TextAsset booleanJson;

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
    public bool ClueUpdated
    {
        get => clueUpdated;
        set => clueUpdated = value;
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

    public void ChangeClueData(int num)
    {
        int counter = 0;
        string cluesText = File.ReadAllText(Application.dataPath + "/Resources/clueBool.json");
        Collected collected = JsonUtility.FromJson<Collected>(cluesText);
        foreach (int clue in collected.collectedClue.ToArray())
        {
            if (counter < num)
                counter++;
            else
                collected.collectedClue[num] = 1;
        }
        string json = JsonUtility.ToJson(collected);
        File.WriteAllText(Application.dataPath + "/Resources/clueBool.json", json);
        clueUpdated = false;
    }
}
