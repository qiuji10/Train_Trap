using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PryOpenLocker : MonoBehaviour
{
    public bool InRange = false;
    public bool hastoolBox = false;
    private bool hasCrowbar;
    private int Count;
    public GameObject toolbox;
    public Locker boolBoy;
    private Inventory inventory;

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InRange && Input.GetKeyDown(KeyCode.R))
        {
            hasCrowbar = PlayerCore.instance.CheckItem(ref Count, "Crowbar");
            
            if (hasCrowbar )
            {
               if (hastoolBox == false)
                {
                    Instantiate(toolbox);
                    Debug.Log("IS OPEN");
                
                    GameObject g = GameObject.FindGameObjectWithTag("locker");
                    boolBoy = g.GetComponent<Locker>();
                    boolBoy.hasToolBox = true;
                    hastoolBox = true; 
                    for (int k = 0; k < inventory.slots.Length; k++)
                    {
                        inventory.slots[k].transform.GetComponentInChildren<Text>().text = PlayerCore.instance.inventoryName[k];
                    }
                }
               

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.CompareTag("Player"))
        {
            InRange = true;
            Debug.Log("Player is in Range");
        }
    }

    private void OnTriggerExit2D(Collider2D collide )
    {
        if (collide.gameObject.CompareTag("Player"))
        {
            InRange = false;
            Debug.Log("Player is not in Range");
        }
    }
}