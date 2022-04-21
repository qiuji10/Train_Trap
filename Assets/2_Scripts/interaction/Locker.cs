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
            //Debug.Log("using locker true");
            Keypad.SetActive(true);
        }

        if (isInRange && Input.GetKeyDown(KeyCode.Escape))
        {
            usingLocker = false;
            //Debug.Log("using locker false");
            Keypad.SetActive(false);
        }

        if (isInRange == false)
        {
            usingLocker = false;
            //Debug.Log("using locker false");
            Keypad.SetActive(false);
        }

    }

        public void SpawnToolBox()
    {
        Instantiate(toolbox, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Quaternion.identity);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            PlayerCore.instance.KeyE = true;
            //Debug.Log("Player is in Range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            PlayerCore.instance.KeyE = false;
            //Debug.Log("Player is not in Range");
        }
    }
}
