using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    public bool isInRange;


    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        
        if (isInRange == true )
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // spawn item at the first available inventory slot
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.isFull[i] == false)
                    { // check whether the slot is EMPTY
                        PlayerCore.instance.inventoryName[i] = gameObject.tag;
                        inventory.isFull[i] = true; // makes sure that the slot is now considered FULL
                        Instantiate(itemButton, inventory.slots[i].transform, false); // spawn the button so that the player can interact with it
                        inventory.slots[i].transform.GetComponentInChildren<Text>().text = PlayerCore.instance.inventoryName[i];
                        Destroy(gameObject);
                        break;
                    }
                }

            }
        }
    }

    public void UpdateSlotName()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            inventory.slots[i].transform.GetComponentInChildren<Text>().text = PlayerCore.instance.inventoryName[i];
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player is in Range");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player is not in Range");
        }
    }
}

