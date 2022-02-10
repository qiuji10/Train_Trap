using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerCore))]
public class NpcInteraction : MonoBehaviour
{
    public bool isInRange, isInteracted = false;
    public KeyCode interactKey;

    public UnityEvent interactAction, interactAction2;

    void Update()
    {
        if(isInRange)
        {
            if(Input.GetKeyDown(interactKey))
            {
                if (!isInteracted)
                {
                    interactAction.Invoke();
                    isInteracted = true;
                }
                else
                {
                    interactAction2.Invoke();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player is in Range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player is not in Range");
        }
    }
}


