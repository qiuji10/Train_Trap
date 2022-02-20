using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendingMachine : MonoBehaviour
{
    public bool isInRange = false;
    private int i;
    public GameObject coke;
    private Inventory inventory;

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            foreach (string item in PlayerCore.instance.inventoryName)
            {
                if (item == "coin")
                {
                    PlayerCore.instance.inventoryName.RemoveAt(i);
                    inventory.isFull[i] = false;
                    Instantiate(coke);
                    PlayerCore.instance.inventoryName.Add("");
                    Destroy(GameObject.FindGameObjectWithTag("coin"));
                    for (int i = 0; i < inventory.slots.Length; i++)
                    {
                        inventory.slots[i].transform.GetComponentInChildren<Text>().text = PlayerCore.instance.inventoryName[i];
                    }
                    // here should be destroy the coin from iventory slot, but not sure how to do
                    break;
                }
                i++;
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
