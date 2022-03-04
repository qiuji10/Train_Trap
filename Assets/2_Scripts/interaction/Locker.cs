using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Locker : MonoBehaviour
{
    public bool isInRange = false;
    public GameObject toolbox;
    public GameObject Keypad;
    public bool keypad = false;
    private Inventory inventory;
    public bool hasToolBox = false;
   




    // Update is called once per frame
    void Update()
    {
        
        if (isInRange && hasToolBox == false  && Input.GetKeyDown(KeyCode.E))
        {
            Keypad.SetActive(true);
            hasToolBox = true;
            PlayerCore.instance.inventoryName.Add("");
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                inventory.slots[i].transform.GetComponentInChildren<Text>().text = PlayerCore.instance.inventoryName[i];
            }
        }

        if (isInRange && Input.GetKeyDown(KeyCode.Escape))
        {
            Keypad.SetActive(false);
        }

        if (isInRange == false)
        {
            Keypad.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            PlayerCore.instance.KeyE = true;
            Debug.Log("Player is in Range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            PlayerCore.instance.KeyE = false;
            Debug.Log("Player is not in Range");
        }
    }

    
}
