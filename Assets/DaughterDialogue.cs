using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DaughterDialogue : MonoBehaviour
{
   
    public UnityEvent noDrink, hasDrink;

    public bool isInRange = false;
    public bool givenDrink, questInteracted, questComplete;

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {

            if (!questInteracted)
            {
                noDrink.Invoke();
                questInteracted = true;
            }
                
            if (givenDrink)
            {
                if (!questComplete)
                {
                    hasDrink.Invoke();
                    questComplete = true;
                }
            }
   

        }
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
