using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStartDialogue : MonoBehaviour
{
    private int pdc;
    private bool isTriggered;

    public UnityEvent StartDialogue, NextSentence;

    void Start()
    {
        pdc = PlayerPrefs.GetInt("PlayerDieCount");
        if (pdc != 1)
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (pdc == 1 && isTriggered)
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
