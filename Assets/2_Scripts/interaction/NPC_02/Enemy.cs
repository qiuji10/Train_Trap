using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Enemy : MonoBehaviour
{
    public bool gotHit;
    private int num;
    public Animator guardAnimator, cfAnimator;
    public UnityEvent allowAccess, denyAccess, getCaught, changeBackDialogue;
    public GameObject player, crossFade;

    void Awake()
    {
        cfAnimator = crossFade.GetComponent<Animator>();
    }

    public void Update()
    {
        if (gotHit == true)
        {
            StartWake();
        }
    }

    public void StartWake()
    {
        StartCoroutine(Wakey());
    }

    private IEnumerator Wakey()
    {
        gotHit = false;
        guardAnimator.SetBool("isKnocked", true);
        allowAccess.Invoke();
        yield return new WaitForSeconds(10f);
        guardAnimator.SetBool("isKnocked", false);
        //should close again the passAccess and check if player still in upper train the guard should kick him off
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
        if (!PlayerCore.instance.CheckItem(ref num, "ticket"))
            denyAccess.Invoke();
    }
}
