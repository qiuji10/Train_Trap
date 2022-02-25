using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Enemy : MonoBehaviour
{
    public int health;
    public bool isInRange;
    public Animator guardAnimator, cfAnimator;
    public float dazedTime;
    public float startDazedTime;
    public UnityEvent allowAccess, denyAccess, getCaught, changeBackDialogue;
    public GameObject player, crossFade;
    void Start()
    {
        cfAnimator = crossFade.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            
            if (Input.GetKeyDown(KeyCode.F))
            {
                StartWake();
            }
        }


    }

    private void StartWake()
    {
        StartCoroutine(Wakey());
    }

    private IEnumerator Wakey()
    {
        PlayerCore.instance.ActivateDistract = false;
        yield return new WaitForSeconds(3f);
        guardAnimator.SetBool("activateDistract", true);
        allowAccess.Invoke();
        yield return new WaitForSeconds(25f);
        guardAnimator.SetBool("activateDistract", false);
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
            player.transform.position = new Vector3(41.23f, player.transform.position.y, player.transform.position.z);
            yield return new WaitForSeconds(1f);
            guardAnimator.SetBool("caughtPlayer", false);
            crossFade.SetActive(false);
            GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
        }
        changeBackDialogue.Invoke();
        denyAccess.Invoke();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player is in Range");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player is not in Range");
        }
    }

}
