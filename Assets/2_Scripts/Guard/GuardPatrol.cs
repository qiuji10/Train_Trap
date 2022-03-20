using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardPatrol : MonoBehaviour
{
    [HideInInspector]
    public bool mustPatrol;
    public Rigidbody2D rb;
    public float WalkSpeed;
    public Transform player, groundCheckPos;
    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;

    }

    // Update is called once per frame
    void Update()
    {
     
            if (mustPatrol)
        {
            Patrol();
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

    
}
