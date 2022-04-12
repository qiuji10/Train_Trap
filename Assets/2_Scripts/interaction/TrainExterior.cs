using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainExterior : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            animator.SetBool("playerIn", true);
            animator.SetBool("playerOut", false);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            animator.SetBool("playerOut", true);
            animator.SetBool("playerIn", false);
        }
    }
}
