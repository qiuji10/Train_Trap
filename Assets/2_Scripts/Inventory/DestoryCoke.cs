using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryCoke : MonoBehaviour
{
    public bool hasTicket = false;
    private int loopCount = 0;

    public GameObject ticketPrefab;

    void Update()
    {
        checkItem(loopCount);
        if (hasTicket == true)
        {
             
                Destroy(GameObject.FindGameObjectWithTag("Coke"));
                
            
        }
    }

    void checkItem(int i)
    {
        foreach (string item in PlayerCore.instance.inventoryName)
        {
            if (item == "ticket")
            {
                hasTicket = true;

                break;
            }
            i++;
        }
    }
}
