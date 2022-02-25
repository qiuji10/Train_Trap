using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class Options
{
    [TextArea(3, 10)]
    public List<string> conversation;
    [TextArea(3, 10)]
    public List<string> readingMinds;
    [TextArea(3, 10)]
    public List<string> specialDialogue;
}

[System.Serializable]
public class NPCs
{
    public string npcName;
    public List<Options> options;
}

[System.Serializable]
public class AllBranches
{
    public List<NPCs> npcs;
}

public class DialogueDatabase : MonoBehaviour
{
    [SerializeField]
    List<GameObject> npc = new List<GameObject>();
    public AllBranches allBranches;
    public TextAsset jsonText;
    int i = 0;

    void Start()
    {
        allBranches = JsonUtility.FromJson<AllBranches>(jsonText.text);
        foreach (Transform child in transform)
        {
            npc.Add(child.gameObject);
            child.gameObject.name = allBranches.npcs[i].npcName;
            child.gameObject.GetComponent<DialogueTrigger>().dialogue.name = child.gameObject.name;
            child.gameObject.GetComponent<DialogueTrigger>().readMinds.name = child.gameObject.name + " (Reading Minds)";
            string[] array = allBranches.npcs[i].options[0].conversation.ToArray();
            child.gameObject.GetComponent<DialogueTrigger>().dialogue.sentences = array;
            string[] array2 = allBranches.npcs[i++].options[0].readingMinds.ToArray();
            child.gameObject.GetComponent<DialogueTrigger>().readMinds.sentences = array2;
        }
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.S))
    //    {
    //        //this is to generate a template for editing later not intended for in-game
    //        string json = JsonUtility.ToJson(allBranches);
    //        PlayerPrefs.SetString("SaveData", json); // can convert to a textfile instead of player pref
    //        Debug.Log(json);
    //    }

    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        string res = PlayerPrefs.GetString("SaveData");
    //        allBranches = JsonUtility.FromJson<AllBranches>(res);
    //    }
    //}

    public void changeDialogue()
    {
        string[] array = allBranches.npcs[0].options[0].specialDialogue.ToArray();
        gameObject.transform.GetComponentInChildren<DialogueTrigger>().dialogue.sentences = array;
    }

    public void changeDialogue2()
    {
        string[] array = allBranches.npcs[1].options[0].specialDialogue.ToArray();
        gameObject.transform.GetChild(1).GetComponentInChildren<DialogueTrigger>().dialogue.sentences = array;
    }

    public void changeDialogue3()
    {
        string[] array = allBranches.npcs[1].options[1].specialDialogue.ToArray();
        gameObject.transform.GetChild(1).GetComponentInChildren<DialogueTrigger>().dialogue.sentences = array;
    }

    public void changeDialogue4()
    {
        string[] array = allBranches.npcs[1].options[0].conversation.ToArray();
        gameObject.transform.GetChild(1).GetComponentInChildren<DialogueTrigger>().dialogue.sentences = array;
    }
}
