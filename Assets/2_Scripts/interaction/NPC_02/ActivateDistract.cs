using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDistract : MonoBehaviour
{
    private bool isInRange;
    public GameObject hintText;

    void Update()
    {
        if (isInRange && PlayerCore.instance.ActivateDistract==false && Input.GetKeyDown(KeyCode.E))
        {
            PlayerCore.instance.ActivateDistract = true;
            hintText.SetActive(true);
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
