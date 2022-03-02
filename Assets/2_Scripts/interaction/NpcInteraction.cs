using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NpcInteraction : MonoBehaviour
{
    public bool isInRange;
    public KeyCode dialogueKey, readMindKey;

    public UnityEvent dialogueAction, readMindsAction, nextSentence;

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
                }
                else
                {
                    nextSentence.Invoke();
                }
            }

            if (Input.GetKeyDown(readMindKey))
            {
                if (!DialogueManager.instance.isInteracted)
                {
                    readMindsAction.Invoke();
                    DialogueManager.instance.isInteracted = true;
                }
                else
                {
                    nextSentence.Invoke();
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


