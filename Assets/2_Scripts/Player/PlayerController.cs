using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerCore))]
public class PlayerController : MonoBehaviour
{
    public float speed;
    public bool isMoving = false;

    PlayerCore playerCore;
    Rigidbody2D rb;
    Vector2 movement;

    public BoxCollider2D collide2D;
    public Animator animator;

    void Awake()
    {
        collide2D = GetComponent<BoxCollider2D>();
        playerCore = GetComponent<PlayerCore>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (!playerCore.IsCrouch)
                {
                    Crouch(true);
                    playerCore.IsCrouch = true;
                }
                else
                {
                    Crouch(false);
                    playerCore.IsCrouch = false;
                }
            }
            movement.x = Input.GetAxisRaw("Horizontal");

            if (movement.x != 0)
                isMoving = true;
            else
                isMoving = false;

            animator.SetBool("IsWalking", isMoving);

            if (movement.x > 0)
            {
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (movement.x < 0)
            {
                gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    public void Crouch(bool pressed)
    {
        if (pressed)
        {
            collide2D.size = new Vector2(collide2D.size.x, 0.3f);
        }
        else
        {
            collide2D.size = new Vector2(collide2D.size.x, 1f);
        }
    }
}