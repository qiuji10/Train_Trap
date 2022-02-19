using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketGuard : MonoBehaviour
{
    [SerializeField] private Ticket.KeyType keyType;

    public Ticket.KeyType GetKeyType()
    {
        return keyType;
    }

    public void AllowAccess()
    {
        gameObject.SetActive(false);// removes collision 
    }

}
