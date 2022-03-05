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

    public GameObject screwdriver;
    public GameObject completebar;
    public Slider db;

    Collider fixcollider;

    void Awake()
    {
        db = completebar.GetComponent<Slider>();
        db.maxValue = setTimer;
    }

    private void Start()
    {
        fixcollider = GetComponent<Collider>();
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
                completebar.SetActive(false);
                fixcollider.enabled = !fixcollider.enabled;
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
            PlayerCore.instance.KeyE = PlayerCore.instance.CheckItem(ref i, "toolbox");
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
