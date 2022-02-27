using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool isInRange;
    public bool hasWrench = false;
    private int loopCount = 0;
    public Enemy boolBoy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkItem(loopCount);
        if (isInRange && hasWrench == true)
        {

            if (Input.GetKeyDown(KeyCode.F))
            {

                GameObject g = GameObject.FindGameObjectWithTag("guard");

                boolBoy = g.GetComponent<Enemy>();

                boolBoy.gotHit = true;


            }
        }
    }

    
    void checkItem(int i)
    {
        foreach (string item in PlayerCore.instance.inventoryName)
        {
            if (item == "wrench")
            {
                hasWrench = true;
                break;
            }
            i++;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("guard"))
        {
            isInRange = true;
            Debug.Log("Player is in Range");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("guard"))
        {
            isInRange = false;
            Debug.Log("Player is not in Range");
        }
    }
}
