using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PryOpenLocker : MonoBehaviour
{
    public bool InRange = false;
    public bool hasObject = false;
    public bool usingLocker2 = false;
    private bool hasCrowbar;
    public float setTimer = 5f;
    private float holdTimer;
    private int Count;
    public GameObject Object,LockerOpen,LockerClose, LockerBar2;
    private Inventory inventory;
    public Slider db;

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        db = LockerBar2.GetComponent<Slider>();
        db.maxValue = setTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (InRange && Input.GetKeyDown(KeyCode.E))
         hasCrowbar = PlayerCore.instance.CheckItem(ref Count, "Crowbar");

            if (InRange && hasCrowbar && Input.GetKey(KeyCode.E))
            {
            usingLocker2 = true;
            if (LockerBar2 != null)
                    {
                        LockerBar2.SetActive(true);
                    }
                holdTimer -= Time.deltaTime;
                db.value = holdTimer;

                if (holdTimer < 0)
                {
                     if (hasObject == false)
                    {
                        LockerBar2.SetActive(false);
                        Instantiate(Object);
                        LockerOpen.SetActive(true);
                        LockerClose.SetActive(false); 
                        Debug.Log("IS OPEN");
                        hasObject = true;
                        for (int k = 0; k < inventory.slots.Length; k++)
                        {
                            inventory.slots[k].transform.GetComponentInChildren<Text>().text = PlayerCore.instance.inventoryName[k];
                        }
                    }


                }
        
               
            }else
                {
            usingLocker2 = false; 
            holdTimer = setTimer;
                    db.value = setTimer;
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

    private void OnTriggerExit2D(Collider2D collide)
    {
        if (collide.gameObject.CompareTag("Player"))
        {
            InRange = false;
            Debug.Log("Player is not in Range");
            LockerBar2.SetActive(false);
        }
    }
}