using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardPatrol : MonoBehaviour
{
    [HideInInspector]
    public bool mustPatrol,playerinRange;
    public Rigidbody2D rb;
    public float WalkSpeed;
    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    public Locker playerUseLocker;


    void Start()
    {
        mustPatrol = true;
        
    }

    
    void Update()
    {
     
            if (mustPatrol)
        {
            Patrol();
        }

           if(playerinRange && playerUseLocker.usingLocker == true)
        {
            Debug.Log("Catch Player");
        }
    }

    void Patrol()
    {
        rb.velocity = new Vector2(WalkSpeed * Time.fixedDeltaTime, rb.velocity.y);


         if (Time.time > nextActionTime)
        {
            nextActionTime = Time.time + period;
            Flip();
        }
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        WalkSpeed *= -1;
        mustPatrol = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerinRange = true;
            Debug.Log("Player is in Range with guard");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerinRange = false;
            Debug.Log("Player is not in Range with guard");
        }
    }


}
