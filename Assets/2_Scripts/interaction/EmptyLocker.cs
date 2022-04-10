using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmptyLocker : MonoBehaviour
{
    public bool InRange = false;
    public bool usingLocker3 = false;
    public bool hasObject = false;
    private bool hasCrowbar;
    public float setTimer = 5f;
    private float holdTimer;
    private int Count;
    public GameObject LockerOpen, LockerClose,LockerBar;
    public Slider db;


    void Awake()
    {
        db = LockerBar.GetComponent<Slider>();
        db.maxValue = setTimer;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (InRange && Input.GetKeyDown(KeyCode.E))
            hasCrowbar = PlayerCore.instance.CheckItem(ref Count, "Crowbar");

            if (InRange && hasCrowbar && Input.GetKey(KeyCode.E))
            {
                usingLocker3 = true;
                if (LockerBar != null)
                {
                    LockerBar.SetActive(true);
                }
                holdTimer -= Time.deltaTime;
                db.value = holdTimer;

                if (holdTimer < 0)
                {
                    LockerOpen.SetActive(true);
                    LockerClose.SetActive(false);
                    LockerBar.SetActive(false);
                     usingLocker3 = false;
            }
            }else
            {
                usingLocker3 = false; 
                holdTimer = setTimer;
                db.value = setTimer;
            }
            
        
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.CompareTag("Player"))
        {
            InRange = true;
            Debug.Log("Player is in Range");
        }
    }

    private void OnTriggerExit2D(Collider2D collide)
    {
        if (collide.gameObject.CompareTag("Player"))
        {
            InRange = false;
            Debug.Log("Player is not in Range");
            LockerBar.SetActive(false);
        }
    }
}
