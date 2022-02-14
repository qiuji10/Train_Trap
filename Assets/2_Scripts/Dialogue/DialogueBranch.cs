using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class Options
{
    [TextArea(3, 10)]
    public List<string> conversation;
    public List<string> readingMinds;
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

public class DialogueBranch : MonoBehaviour
{
    [SerializeField]
    List<GameObject> npc = new List<GameObject>();
    public AllBranches allBranches;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform) 
        {
            npc.Add(child.gameObject);
            child.gameObject.name = allBranches.npcs[i].npcName;
            string[] array = allBranches.npcs[i++].options[0].conversation.ToArray();
            child.gameObject.GetComponent<DialogueTrigger>().dialogue.sentences = array;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
