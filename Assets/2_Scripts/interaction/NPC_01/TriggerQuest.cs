using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TriggerQuest : MonoBehaviour
{
    private bool isInRange;
    private bool hasCoke = false;
    private bool takenCola = false;
    private int loopCount = 0;

    private Inventory inventory;
    public GameObject ticketPrefab;
    public UnityEvent triggerQuest;

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E) && !takenCola)
        {
            hasCoke = PlayerCore.instance.CheckItem(ref loopCount, "coke");
            if (hasCoke)
            {
                triggerQuest.Invoke();
                PlayerCore.instance.inventoryName.RemoveAt(loopCount);
                inventory.isFull[loopCount] = false;
                Instantiate(ticketPrefab);
                PlayerCore.instance.inventoryName.Add("");
                isInRange = false;
                takenCola = true;
                Destroy(GameObject.FindGameObjectWithTag("coke"));
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    inventory.slots[i].transform.GetComponentInChildren<Text>().text = PlayerCore.instance.inventoryName[i];
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
