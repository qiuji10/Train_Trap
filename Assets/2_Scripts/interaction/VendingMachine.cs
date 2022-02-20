using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VendingMachine : MonoBehaviour
{
    public bool isInRange = false;
    private int i;
    public GameObject coke;

    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            foreach (string item in PlayerCore.instance.inventoryName)
            {
                if (item == "coin")
                {
                    //display msg and instantiate coke
                    PlayerCore.instance.inventoryName.RemoveAt(i);
                    Instantiate(coke);
                    PlayerCore.instance.inventoryName.Add("");
                    // here should be destroy the coin from iventory slot, but not sure how to do
                    break;
                }
                i++;
            }
            //display no coin found in inventory
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
