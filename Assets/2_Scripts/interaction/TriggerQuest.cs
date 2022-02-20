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
        checkItem(loopCount);
        if (isInRange && hasCoke && takenCola==false)
        {
            triggerQuest.Invoke();
            Destroy(GameObject.FindGameObjectWithTag("coke"));
            inventory.slots[loopCount].transform.GetComponentInChildren<Text>().text = PlayerCore.instance.inventoryName[loopCount];
            if (Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(ticketPrefab);
                inventory.isFull[loopCount] = false;
                PlayerCore.instance.inventoryName.RemoveAt(loopCount);
                PlayerCore.instance.inventoryName.Add("");
                isInRange = false;
                takenCola = true;
            }
        }
    }

    void checkItem(int i)
    {
        foreach (string item in PlayerCore.instance.inventoryName)
        {
            if (item == "coke")
            {
                hasCoke = true;
                break;
            }
            i++;
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
