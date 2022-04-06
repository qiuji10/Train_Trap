using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmptyLocker : MonoBehaviour
{
    public bool InRange = false;
    public bool hasObject = false;
    private bool hasCrowbar;
    private int Count;
   
  
   

    // Update is called once per frame
    void Update()
    {
        if (InRange && Input.GetKeyDown(KeyCode.R))
        {
            hasCrowbar = PlayerCore.instance.CheckItem(ref Count, "Crowbar");

            if (hasCrowbar)
            {
               

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.CompareTag("Player"))
        {
            InRange = true;
            Debug.Log("Player is in Range");
        }
    }

    private void OnTriggerExit2D(Collider2D collide)
    {
        if (collide.gameObject.CompareTag("Player"))
        {
            InRange = false;
            Debug.Log("Player is not in Range");
        }
    }
}
