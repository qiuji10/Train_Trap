using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CashierQuest : MonoBehaviour
{
    private bool isInRange;
    private bool hasCoin = false;
    private bool takenCoin = false;
    private int loopCount = 0;

    private Inventory inventory;
    public GameObject newspaperPrefab;
    public UnityEvent cashierQuest;
    Vector3 spawnPos;

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        spawnPos = new Vector3(transform.position.x, -4.1f, transform.position.z);
    }

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E) && !takenCoin)
        {
            hasCoin = PlayerCore.instance.CheckItem(ref loopCount, "coin");
            if (hasCoin)
            {
                cashierQuest.Invoke();
                PlayerCore.instance.inventoryName.Insert(loopCount, "");
                PlayerCore.instance.inventoryName.RemoveAt(loopCount + 1);
                inventory.isFull[loopCount] = false;
                Instantiate(newspaperPrefab, spawnPos, Quaternion.identity);
                isInRange = false;
                takenCoin = true;
                Destroy(GameObject.FindGameObjectWithTag("coin"));
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

