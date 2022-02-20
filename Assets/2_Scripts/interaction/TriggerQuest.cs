using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerQuest : MonoBehaviour
{
    public bool hasCoke = false;
    private bool isInRange;
    private int loopCount = 0;

    public GameObject ticketPrefab;
    public UnityEvent triggerQuest;

    void Update()
    {
        checkItem(loopCount);
        if (isInRange && hasCoke)
        {
            triggerQuest.Invoke();
            if (Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(ticketPrefab);
                PlayerCore.instance.inventoryName.RemoveAt(loopCount);
                isInRange = false;
            }
        }
    }

    void checkItem(int i)
    {
        foreach (string item in PlayerCore.instance.inventoryName)
        {
            if (item == "coke")
            {
                hasCoke = true;
                break;
            }
            i++;
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
