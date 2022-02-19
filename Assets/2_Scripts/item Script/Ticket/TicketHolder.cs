using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketHolder : MonoBehaviour
{
    private List<Ticket.KeyType> keyList;

    private void Awake()
    {
        keyList = new List<Ticket.KeyType>();
    }

    public void AddKey(Ticket.KeyType keyType)
    {
        Debug.Log("key added : "+ keyType);
        keyList.Add(keyType);
    }

    public void RemoveKey(Ticket.KeyType keyType)
    {
        keyList.Remove(keyType);
    }

    public bool ContainsKey(Ticket.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Ticket key = collider.GetComponent<Ticket>();
        if (key != null)
        {
            AddKey(key.GetKeyType());

        }

        TicketGuard TicketGuard = collider.GetComponent<TicketGuard>(); // if we collied to the guard 
        if (TicketGuard != null)
        {
            
                if (ContainsKey(TicketGuard.GetKeyType())) // check if the item is correct 
                {

                    //currently holding key to open door
                    RemoveKey(TicketGuard.GetKeyType()); // remove ticket from player 
                    TicketGuard.AllowAccess(); // allows player to enter upper class 

                }
            
        }
    
    }


}
