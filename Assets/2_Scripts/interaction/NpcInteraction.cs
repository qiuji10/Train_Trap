using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NpcInteraction : MonoBehaviour
{
    public bool isInRange;
    private bool inDialogue, inReadMind;
    public KeyCode dialogueKey, readMindKey;

    public UnityEvent dialogueAction, readMindsAction, nextSentence;
    DialogueManager dm;

    private void Awake()
    {
        dm = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {
        if(isInRange)
        {
            if(Input.GetKeyDown(dialogueKey))
            {
                if (!DialogueManager.instance.isInteracted)
                {
                    dialogueAction.Invoke();
                    DialogueManager.instance.isInteracted = true;
                    inDialogue = true;
                }
                else if (inDialogue)
                {
                    nextSentence.Invoke();
                    if (!dm.dialogueBox.activeInHierarchy)
                        inDialogue = false;
                }
            }

            if (Input.GetKeyDown(readMindKey))
            {
                if (!DialogueManager.instance.isInteracted)
                {
                    readMindsAction.Invoke();
                    DialogueManager.instance.isInteracted = true;
                    inReadMind = true;
                }
                else if (inReadMind)
                {
                    nextSentence.Invoke();
                    if (!dm.dialogueBox.activeInHierarchy)
                        inReadMind = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            PlayerCore.instance.KeyE = true;
            PlayerCore.instance.KeyR = true;
            Debug.Log("Player is in Range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            PlayerCore.instance.KeyE = false;
            PlayerCore.instance.KeyR = false;
            Debug.Log("Player is not in Range");
        }
    }
}


