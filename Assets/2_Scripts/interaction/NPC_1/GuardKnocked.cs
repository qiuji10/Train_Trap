using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class GuardKnocked : MonoBehaviour
{
    public bool gotHit;
    private int num, loopCount;
    public Animator guardAnimator, cfAnimator;
    public UnityEvent allowAccess, denyAccess, getCaught, changeBackDialogue;
    public GameObject player, crossFade;
    DialogueManager dm;
    Inventory inventory;
    DistractGuard dg;
    NpcInteraction npcInteract;

    void Awake()
    {
        cfAnimator = crossFade.GetComponent<Animator>();
        dg = GetComponent<DistractGuard>();
        npcInteract = GetComponent<NpcInteraction>();
        dm = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void Update()
    {
        if (gotHit == true)
        {
            npcInteract.enabled = false;
            dg.enabled = false;
            StartWake();
        }
    }

    public void StartWake()
    {
        if (!dm.dialogueBox.activeInHierarchy)
            StartCoroutine(Wakey());
    }

    private IEnumerator Wakey()
    {
        gotHit = false;
        guardAnimator.SetBool("isKnocked", true);
        allowAccess.Invoke();
        yield return new WaitForSeconds(10f);
        guardAnimator.SetBool("isKnocked", false);
        npcInteract.enabled = true;
        dg.enabled = true;
        //should close again the passAccess and check if player still in upper train the guard should kick him off
        if (!PlayerCore.instance.CheckItem(ref num, "ticket"))
        {
            if (player.transform.position.x > transform.position.x)
            {
                GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
                dg.enabled = false;
                npcInteract.enabled = false;
                guardAnimator.SetBool("caughtPlayer", true);
                yield return new WaitForSeconds(1f);
                getCaught.Invoke();
                //cutscene animation
                yield return new WaitForSeconds(3f);
                crossFade.SetActive(true);
                yield return new WaitForSeconds(2f);
                guardAnimator.SetBool("caughtPlayer", false);
                player.transform.position = new Vector3(41.23f, player.transform.position.y, player.transform.position.z);
                dm.dialogueBox.SetActive(false);
                dm.slot.SetActive(true);
                if (PlayerCore.instance.CheckItem(ref loopCount, "wrench"))
                {
                    PlayerCore.instance.inventoryName.Insert(loopCount, "");
                    PlayerCore.instance.inventoryName.RemoveAt(loopCount + 1);
                    inventory.isFull[loopCount] = false;
                    Destroy(GameObject.FindGameObjectWithTag("slot_wrench"));
                    for (int i = 0; i < inventory.slots.Length; i++)
                    {
                        inventory.slots[i].transform.GetComponentInChildren<Text>().text = PlayerCore.instance.inventoryName[i];
                    }
                }
                yield return new WaitForSeconds(1f);
                crossFade.SetActive(false);
                GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
                dg.enabled = true;
                npcInteract.enabled = true;
            }
            changeBackDialogue.Invoke();
            denyAccess.Invoke();
        }
    }
}
