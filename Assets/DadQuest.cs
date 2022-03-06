using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DadQuest : MonoBehaviour
{
    public UnityEvent dadQuest, doneQuest;
    private Inventory inventory;
    public GameObject coin, newspaper;

    private bool isInRange;
    private bool has7up = false;
    private bool taken7up = false;
    public bool questInteracted, questDone;
    private int loopCount = 0;

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E) && !taken7up)
        {
            if (!questInteracted)
            {
                dadQuest.Invoke();
                PlayerCore.instance.inventoryName.Insert(loopCount, "");
                inventory.isFull[loopCount] = false;
                Instantiate(coin);
                isInRange = false;
                questInteracted = true;
            }
            
            if (!questDone)
            {
                has7up = PlayerCore.instance.CheckItem(ref loopCount, "7up");
                if (has7up)
                {
                    doneQuest.Invoke();
                    PlayerCore.instance.inventoryName.Insert(loopCount, "");
                    PlayerCore.instance.inventoryName.RemoveAt(loopCount + 1);
                    inventory.isFull[loopCount] = false;
                    Instantiate(newspaper);
                    isInRange = false;
                    taken7up = true;
                    Destroy(GameObject.FindGameObjectWithTag("7up"));
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

