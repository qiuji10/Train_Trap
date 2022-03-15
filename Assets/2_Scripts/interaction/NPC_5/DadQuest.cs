using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DadQuest : MonoBehaviour
{
    public DaughterDialogue dd;
    public UnityEvent dadQuest, doneQuest;
    private Inventory inventory;
    public GameObject coin, newspaper;

    private bool isInRange;
    private bool hasOJ = false;
    private bool takenOJ = false;
    public bool questInteracted, questDone;
    private int loopCount = 0;

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E) && !takenOJ)
        {
            if (!questInteracted)
            {
                dadQuest.Invoke();
                Instantiate(coin);
                isInRange = false;
                questInteracted = true;
            }
            
            if (!questDone)
            {
                hasOJ = PlayerCore.instance.CheckItem(ref loopCount, "Orange_Juice");
                if (hasOJ)
                {
                    doneQuest.Invoke();

                    GameObject d = GameObject.FindGameObjectWithTag("daughter");
                    dd = d.GetComponent<DaughterDialogue>();
                    dd.givenDrink = true;

                    PlayerCore.instance.inventoryName.Insert(loopCount, "");
                    PlayerCore.instance.inventoryName.RemoveAt(loopCount + 1);
                    inventory.isFull[loopCount] = false;
                    Instantiate(newspaper);
                    isInRange = false;
                    takenOJ = true;
                    Destroy(GameObject.FindGameObjectWithTag("slot_orangejuice"));
                    for (int i = 0; i < inventory.slots.Length; i++)
                    {
                        inventory.slots[i].transform.GetComponentInChildren<Text>().text = PlayerCore.instance.inventoryName[i];
                    }

                    questDone = true;

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

