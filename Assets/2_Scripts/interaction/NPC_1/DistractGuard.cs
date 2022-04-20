using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DistractGuard : MonoBehaviour
{
    private int num;
    private bool isInRange, dialogueChanged;
    public UnityEvent changeGuardDialogue, allowAccess, denyAccess, getCaught, changeBackDialogue;
    public Animator guardAnimator;
    public Animator cfAnimator;
    public GameObject player, crossFade, hintText;
    DialogueManager dm;
    GuardKnocked gk;
    PlayerAttack pa;
    BoxCollider2D bc;

    private void Awake()
    {
        cfAnimator = crossFade.GetComponent<Animator>();
        gk = GetComponent<GuardKnocked>();
        bc = GetComponent<BoxCollider2D>();
        pa = FindObjectOfType<PlayerAttack>();
        dm = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }

    void Update()
    {
        if (isInRange && PlayerCore.instance.ActivateDistract == true)
        {
            if (!dialogueChanged)
            {
                changeGuardDialogue.Invoke();
                dialogueChanged = true;
            }


            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log(dm.dialogueBox.activeInHierarchy);
                gk.enabled = false;
                pa.enabled = false;
                hintText.SetActive(false);
                StartDistract();
            }
        }
    }

    private void StartDistract()
    {
        Debug.Log("StartDistract");
        if (!dm.dialogueBox.activeInHierarchy)
            StartCoroutine(StorySequence());
    }

    private IEnumerator StorySequence()
    {
        bc.enabled = false;
        PlayerCore.instance.ActivateDistract = false;
        guardAnimator.SetBool("activateDistract", true);
        allowAccess.Invoke();
        yield return new WaitForSeconds(24f);
        guardAnimator.SetBool("activateDistract", false);
        gk.enabled = true;
        pa.enabled = true;
        //should close again the passAccess and check if player still in upper train the guard should kick him off

        if (!PlayerCore.instance.CheckItem(ref num, "ticket"))
        {
            if (player.transform.position.x > transform.position.x)
            {
                GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
                gk.enabled = false;
                pa.enabled = false;
                guardAnimator.SetBool("caughtPlayer", true);
                yield return new WaitForSeconds(1f);
                getCaught.Invoke();
                //cutscene animation
                yield return new WaitForSeconds(3f);
                crossFade.SetActive(true);
                yield return new WaitForSeconds(2f);
                PlayerCore.instance.ActivateDistract = false;
                dm.dialogueBox.SetActive(false);
                guardAnimator.SetBool("caughtPlayer", false);
                player.transform.position = new Vector3(41.23f, player.transform.position.y, player.transform.position.z);
                yield return new WaitForSeconds(1f);
                crossFade.SetActive(false);
                GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
                pa.enabled = true;
                gk.enabled = true;
                dm.isInteracted = false;
            }
            changeBackDialogue.Invoke();
            denyAccess.Invoke();
            bc.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
