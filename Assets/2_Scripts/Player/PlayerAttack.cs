using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool isInRange;
    public bool hasWrench = false;
    private int loopCount = 0;
    public GuardKnocked boolBoy;

    // Update is called once per frame
    void Update()
    {
        hasWrench = PlayerCore.instance.CheckItem(ref loopCount, "wrench");
        if (isInRange && hasWrench)
        {
            PlayerCore.instance.KeyF = true;
            if (Input.GetKeyDown(KeyCode.F))
            {

                GameObject g = GameObject.FindGameObjectWithTag("guard");

                boolBoy = g.GetComponent<GuardKnocked>();

                boolBoy.gotHit = true;


            }
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
            PlayerCore.instance.KeyF = false;
            Debug.Log("Player is not in Range");
        }
    }
}
