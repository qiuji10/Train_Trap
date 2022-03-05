using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DistractGuard : MonoBehaviour
{
    private int num;
    private bool isInRange;
    public UnityEvent changeGuardDialogue, allowAccess, denyAccess, getCaught, changeBackDialogue;
    public Animator guardAnimator;
    public Animator cfAnimator;
    public GameObject player, crossFade, hintText;

    private void Awake()
    {
        cfAnimator = crossFade.GetComponent<Animator>();
    }

    void Update()
    {
        if (isInRange && PlayerCore.instance.ActivateDistract == true)
        {
            changeGuardDialogue.Invoke();
            if (Input.GetKeyDown(KeyCode.E))
            {
                hintText.SetActive(false);
                StartDistract();
            }
        }
    }

    private void StartDistract()
    {
        StartCoroutine(StorySequence());
    }

    private IEnumerator StorySequence()
    {
        PlayerCore.instance.ActivateDistract = false;
        yield return new WaitForSeconds(3f);
        guardAnimator.SetBool("activateDistract", true);
        allowAccess.Invoke();
        yield return new WaitForSeconds(25f);
        guardAnimator.SetBool("activateDistract", false);
        //should close again the passAccess and check if player still in upper train the guard should kick him off

        if (!PlayerCore.instance.CheckItem(ref num, "ticket"))
        {
            if (player.transform.position.x > transform.position.x)
            {
                GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
                guardAnimator.SetBool("caughtPlayer", true);
                yield return new WaitForSeconds(1f);
                getCaught.Invoke();
                //cutscene animation
                yield return new WaitForSeconds(3f);
                crossFade.SetActive(true);
                yield return new WaitForSeconds(2f);
                guardAnimator.SetBool("caughtPlayer", false);
                player.transform.position = new Vector3(41.23f, player.transform.position.y, player.transform.position.z);
                yield return new WaitForSeconds(1f);
                crossFade.SetActive(false);
                GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
            }
            changeBackDialogue.Invoke();
            denyAccess.Invoke();
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
