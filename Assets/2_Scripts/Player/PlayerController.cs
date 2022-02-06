using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerCore))]
public class PlayerController : MonoBehaviour
{
    public float speed;
    
    PlayerCore playerCore;
    public BoxCollider2D collide2D;


    void Awake()
    {
        collide2D = GetComponent<BoxCollider2D>();
        playerCore = GetComponent<PlayerCore>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S)) {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else if (Input.GetKey(KeyCode.A)) {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
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
    }

    public void Crouch(bool pressed)
    {
        if (pressed)
        {
            collide2D.size = new Vector2(collide2D.size.x, 0.3f);
        }
        else
        {
            collide2D.size = new Vector2(collide2D.size.x, 0.6f);
        }
    }
}