using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;

public class PlayerStartDialogue : MonoBehaviour
{
    private int pdc;
    private bool isTriggered;

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
                dt.dialogue.sentences = new string[dt.readMinds.sentences.Length];
                dt.dialogue.sentences = dt.readMinds.sentences;
                gameObject.SetActive(true);
            }
            else
                gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if ((pdc == 1 || Check()) && isTriggered)
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
