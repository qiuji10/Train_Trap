using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

[System.Serializable]
public class Collected
{
    public List<int> collectedClue;
}

public class CluesInPanel : MonoBehaviour
{
    public Collected collected;
    public TextAsset booleanJson;
    [SerializeField] TextMeshProUGUI clueCountText;

    private int clueCount;

    private void Start()
    {
        int i = 0;
        collected = JsonUtility.FromJson<Collected>(booleanJson.text);
        foreach (Transform clueText in transform.GetChild(1).GetChild(0))
        {
            if (!IntToBool(collected.collectedClue[i]))
            {
                clueText.gameObject.SetActive(false);
            }
            else
            {
                clueCount++;
            }
            i++;
        }
        clueCountText.text = clueCount.ToString();
    }

    private void Update()
    {
        int i = 0;
        if (!PlayerCore.instance.ClueUpdated)
        {
            clueCount = 0;
            string cluesText = File.ReadAllText(Application.dataPath + "/Resources/clueBool.json");
            collected = JsonUtility.FromJson<Collected>(cluesText);
            Debug.Log(cluesText);
            foreach (Transform clueText in transform.GetChild(1).GetChild(0)) 
            {
                if (!IntToBool(collected.collectedClue[i]))
                {
                    clueText.gameObject.SetActive(false);
                }      
                else
                {
                    clueText.gameObject.SetActive(true);
                    clueCount++;
                }

                i++;
            }
            clueCountText.text = clueCount.ToString();
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
