using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendingMachine : MonoBehaviour
{
    public bool isInRange = false;
    private bool hasCoin;
    private int loopCount;
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
            hasCoin = PlayerCore.instance.CheckItem(ref loopCount, "coin");
            if (hasCoin)
            {
                PlayerCore.instance.inventoryName.RemoveAt(loopCount);
                inventory.isFull[loopCount] = false;
                Instantiate(coke);
                PlayerCore.instance.inventoryName.Add("");
                Destroy(GameObject.FindGameObjectWithTag("coin"));
                Debug.Log("destory coinnnnnn");
                for (int j = 0; j < inventory.slots.Length; j++)
                {
                    inventory.slots[j].transform.GetComponentInChildren<Text>().text = PlayerCore.instance.inventoryName[j];
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            PlayerCore.instance.KeyE = PlayerCore.instance.CheckItem(ref i, "coin");
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
