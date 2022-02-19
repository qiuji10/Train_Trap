using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BombLocation : MonoBehaviour
{
    public bool isInRange = false;
    private int i;
 

    // Update is called once per frame
    void Update()
    {

        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            foreach (string item in PlayerCore.instance.inventoryName)
            {
                if (item == "ticket")
                {
                    
                    PlayerCore.instance.inventoryName.RemoveAt(i);
                    SceneManager.LoadScene("Win");
                    break;
                }
                i++;
            }
            
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
