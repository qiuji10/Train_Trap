using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GrandmaQuest : MonoBehaviour
{
    private bool isInRange;
    private bool hasScrew = false;
    public bool isFixed;

    private int loopCount = 0;
   
    private Inventory inventory;
    public UnityEvent grandmaQuest;
    public UnityEvent radioFixed;
    

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E) )
        {
            hasScrew = PlayerCore.instance.CheckItem(ref loopCount, "screwdriver");
            if (hasScrew)
            {
                grandmaQuest.Invoke();
               
            }
            if (isFixed == true)
            {
                radioFixed.Invoke();
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
