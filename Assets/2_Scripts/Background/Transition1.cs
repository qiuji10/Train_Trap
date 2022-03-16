using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition1 : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float delay;
    public Timer timer;
    public float time;
    
    
    void Start()
    {
        delay = 170;  
    }

    // Update is called once per frame
    void Update()
    {

       time = timer.timeValue;

        if (delay > time  ) 
        { 

        Vector3 a = transform.position;
        Vector3 b = target.position;
        transform.position = Vector3.MoveTowards(a, b, speed);


        }
    }
}
