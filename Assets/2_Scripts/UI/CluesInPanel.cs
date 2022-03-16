using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
[System.Serializable]
public class Collected
{
    public List<int> collectedClue;
}

public class CluesInPanel : MonoBehaviour
{
    private bool updated;
    public Collected collected;
    public TextAsset booleanJson;

    private void Start()
    {
        int i = 0;
        collected = JsonUtility.FromJson<Collected>(booleanJson.text);
        foreach (Transform clueText in transform.GetChild(1))
        {
            if (!IntToBool(collected.collectedClue[i]))
            {
                clueText.gameObject.SetActive(false);
            }
            i++;
        }
    }

    private void Update()
    {
        int i = 0;
        if (!PlayerCore.instance.ClueUpdated)
        {
            string cluesText = File.ReadAllText(Application.dataPath + "/Resources/clueBool.json");
            collected = JsonUtility.FromJson<Collected>(cluesText);
            Debug.Log(cluesText);
            foreach (Transform clueText in transform.GetChild(1))
            {
                if (!IntToBool(collected.collectedClue[i]))
                    clueText.gameObject.SetActive(false);
                else
                    clueText.gameObject.SetActive(true);
                i++;
            }
            PlayerCore.instance.ClueUpdated = true;
        }        
    }

    public bool IntToBool(int num)
    {
        if (num == 1)
            return true;
        else
            return false;
    }

    
}
