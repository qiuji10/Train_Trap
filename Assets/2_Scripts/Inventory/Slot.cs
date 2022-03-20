using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour

{
    private Inventory inventory;
    private int loopCount;
    public int i;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

   

    public void DropItem()
    {
        inventory.isFull[i] = false;
        transform.GetChild(1).GetComponent<Spawn>().SpawnDroppedItem();
        Destroy(GetComponent<Transform>().GetChild(1).gameObject);
        PlayerCore.instance.inventoryName.Insert(i, "");
        PlayerCore.instance.inventoryName.RemoveAt(i + 1);
        for (int j = 0; j < inventory.slots.Length; j++)
        {
            inventory.slots[j].transform.GetComponentInChildren<Text>().text = PlayerCore.instance.inventoryName[j];
        }



    }
}
