using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket : MonoBehaviour
{
    [SerializeField] private KeyType keyType;
    public enum KeyType
    {
        ticket
    }

    public KeyType GetKeyType()
    {
        return keyType;
    }

}
