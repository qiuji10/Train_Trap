using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixRadio : MonoBehaviour
{
    public bool isInRange = false;
    public bool hasScrew = false;
    public float setTimer = 5f;
    private float holdTimer;
    private int i = 0;
    private int j = 0;

    public GameObject screwdriver;
    public GameObject completebar;
    public Slider db;
    public GrandmaQuest gq;

    AudioSource audioData; 

    void Awake()
    {
        db = completebar.GetComponent<Slider>();
        db.maxValue = setTimer;
    }

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
            hasScrew = PlayerCore.instance.CheckItem(ref i, "screwdriver");

        if (isInRange && hasScrew && Input.GetKey(KeyCode.E))
        {
            completebar.SetActive(true);
            holdTimer -= Time.deltaTime;
            db.value = holdTimer;
            if (holdTimer < 0)
            {
                Debug.Log("Radio is fixed");

                GameObject g = GameObject.FindGameObjectWithTag("grandma");
                gq = g.GetComponent<GrandmaQuest>();
                gq.isFixed = true;

                completebar.SetActive(false);
                GetComponent<BoxCollider2D>().enabled = false;
                audioData = GetComponent<AudioSource>();
                audioData.Play(0);

                PlayerCore.instance.ChangeClueData(1);
            }      
        }
        else
        {
           
            holdTimer = setTimer;
            db.value = setTimer;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            PlayerCore.instance.KeyE = PlayerCore.instance.CheckItem(ref j, "screwdriver");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            PlayerCore.instance.KeyE = false;
            completebar.SetActive(false);
        }
    }
}
