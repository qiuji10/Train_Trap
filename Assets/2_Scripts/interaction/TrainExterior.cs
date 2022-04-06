using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainExterior : MonoBehaviour
{
    SpriteRenderer sp;

    void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            sp.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            sp.enabled = true;
        }
    }
}
