using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DistractGuard : MonoBehaviour
{
    private bool isInRange;
    public UnityEvent changeGuardDialogue, passAccess;
    public Animator guardAnimator;

    void Update()
    {
        if (isInRange && PlayerCore.instance.ActivateDistract == true)
        {
            changeGuardDialogue.Invoke();
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartDistract();
            }
        }
    }

    private void StartDistract()
    {
        StartCoroutine(StorySequence());
    }

    private IEnumerator StorySequence()
    {
        yield return new WaitForSeconds(3f);
        guardAnimator.SetBool("activateDistract", true);
        passAccess.Invoke();
        yield return new WaitForSeconds(25f);
        guardAnimator.SetBool("activateDistract", false);
        //should close again the passAccess and check if player still in upper train the guard should kick him off
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
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
