using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Locker : MonoBehaviour
{
    public bool isInRange = false;
    public bool keypad = false;
    public bool hasToolBox = false;
    public bool usingLocker = false;

    public GameObject toolbox;
    public GameObject Keypad;
    
    void Update()
    {
        
        if (isInRange && hasToolBox == false  && Input.GetKeyDown(KeyCode.E))
        {
            usingLocker = true;
            Keypad.SetActive(true);

        }

        if (isInRange && Input.GetKeyDown(KeyCode.Escape))
        {
            Keypad.SetActive(false);
            usingLocker = false;
        }

        if (isInRange == false)
        {
            Keypad.SetActive(false);
            usingLocker = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            PlayerCore.instance.KeyE = true;
            Debug.Log("Player is in Range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            PlayerCore.instance.KeyE = false;
            Debug.Log("Player is not in Range");
        }
    }
}
