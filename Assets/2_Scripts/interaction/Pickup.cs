using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public bool isInRange;
    public int pdc;

    private Inventory inventory;
    private DialogueManager dm;
    public GameObject itemButton;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        dm = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        pdc = PlayerPrefs.GetInt("PlayerDieCount");
    }

    private void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (pdc == 0)
                {
                    dm.nameText.text = "You";
                    dm.dialogueText.text = "Nah, Im not going to do that";
                    dm.dialogueBox.SetActive(true);
                    SayNo();
                    return;
                }
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

    public void SayNo()
    {
        StartCoroutine(SetDialogueInactive());
    }

    IEnumerator SetDialogueInactive()
    {
        yield return new WaitForSeconds(1f);
        dm.dialogueBox.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerCore.instance.KeyE = true;
            isInRange = true;
            Debug.Log("Player is in Range");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerCore.instance.KeyE = false;
            isInRange = false;
            Debug.Log("Player is not in Range");
        }
    }
}

