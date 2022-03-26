using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;
using System.Linq;

public class PlayerStartDialogue : MonoBehaviour
{
    private int pdc;
    public bool isTriggered;

    public UnityEvent StartDialogue, NextSentence;
    Collected collected;
    DialogueTrigger dt;

    private void Awake()
    {
        dt = GetComponent<DialogueTrigger>();
    }

    void Start()
    {
        string cluesText = File.ReadAllText(Application.dataPath + "/Resources/clueBool.json");
        collected = JsonUtility.FromJson<Collected>(cluesText);

        pdc = PlayerPrefs.GetInt("PlayerDieCount");
        if (pdc != 1)
        {
            if (Check() && PlayerPrefs.GetInt("GetAllClues") == 0)
            {
                PlayerPrefs.SetInt("GetAllClues", 1);
                dt.dialogue.sentences = new string[3];
                dt.dialogue.sentences[0] = "Alright.";
                dt.dialogue.sentences[1] = "I know what is going on.";
                dt.dialogue.sentences[2] = "Gonna end these nightmares now.";
                gameObject.SetActive(true);
            }
            else if (PlayerPrefs.GetInt("MaryPicSpawned") == 1 && PlayerPrefs.GetInt("GetAllClues") == 0)
            {
                if (PlayerPrefs.GetInt("GetMaryPic") == 1)
                {

                    List<string> tmpDialogue = dt.readMinds.sentences.ToList();
                    tmpDialogue.Add("Is a picture of woman and text beside is Mary...");
                    dt.dialogue.sentences = tmpDialogue.ToArray();

                    dt.dialogue.sentences = new string[dt.readMinds.sentences.Length];
                    dt.dialogue.sentences = dt.readMinds.sentences;
                    gameObject.SetActive(true);
                }
                else
                {
                    
                    List<string> tmpDialogue = dt.readMinds.sentences.ToList();
                    tmpDialogue.Add("I need to get it, it might be a clue. ");
                    dt.dialogue.sentences = tmpDialogue.ToArray();
                    gameObject.SetActive(true);
                }
                
            }
            else
                gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if ((pdc == 1 || Check() || PlayerPrefs.GetInt("MaryPicSpawned") == 1 || (PlayerPrefs.GetInt("GetMaryPic") == 1)) && isTriggered)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (DialogueManager.instance.isInteracted)
                {
                    NextSentence.Invoke();
                }
            }

            if (!DialogueManager.instance.isInteracted)
            {
                gameObject.SetActive(false);
                PlayerPrefs.SetInt("MaryPicSpawned", 0);
            }
        }
    }

    bool Check()
    {
        foreach (int collect in collected.collectedClue)
        {
            if (collect == 0)
                return false;
        }
        return true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartDialogue.Invoke();
            DialogueManager.instance.isInteracted = true;
            isTriggered = true;
        }
    }
}
