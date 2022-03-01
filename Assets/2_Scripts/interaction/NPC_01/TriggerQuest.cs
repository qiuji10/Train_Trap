using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TriggerQuest : MonoBehaviour
{
    public bool hasCoke = false;
    private bool isInRange;
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
            foreach (string item in PlayerCore.instance.inventoryName)
            {
                if (item == "coke")
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
                    break;
                }
                loopCount++;
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
