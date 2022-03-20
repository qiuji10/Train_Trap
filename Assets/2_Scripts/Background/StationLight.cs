using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationLight : MonoBehaviour
{
    public float speed = 1f;
    public float timer;
    public Vector2 direction = new Vector2(1, 0);
    private Vector2 velocity, pos;

    void Update()
    {
        
        timer += Time.deltaTime;
        velocity = direction * speed;
        if (timer >= 5)
        {
            timer = 0;
            gameObject.SetActive(false);

        }
    }

    private void FixedUpdate()
    {
        pos = transform.position;
        pos -= velocity * Time.deltaTime;
        transform.position = pos;
    }
}
