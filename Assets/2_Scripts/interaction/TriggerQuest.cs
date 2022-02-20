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
            PlayerCore.instance.inventoryName.RemoveAt(loopCount);
            inventory.slots[loopCount].transform.GetComponentInChildren<Text>().text = PlayerCore.instance.inventoryName[loopCount];
            inventory.isFull[loopCount] = false;
            PlayerCore.instance.inventoryName.Add("");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(ticketPrefab);
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
