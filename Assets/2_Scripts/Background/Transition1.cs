using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition1 : MonoBehaviour
{
    public Transform target;
    public float speed,delay,time, active;
    public Timer timer;
    public GameObject falseBG , trueBg, firstLoopFalse;
    public Vector3 b;
    void Start()
    {
        b = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        
       time = timer.timeValue;

        if (delay > time  ) 
        {
            transform.position = Vector3.MoveTowards(transform.position, b, Time.deltaTime * speed);
        }
        
        if (active > time)
            {
            falseBG.SetActive(false);
            trueBg.SetActive(true);
            }

        if (time < 60)
        {
            firstLoopFalse.SetActive(false); 
        }
    }
}
