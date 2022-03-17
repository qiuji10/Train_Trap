using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition1 : MonoBehaviour
{
    public Transform target;
    public float speed,delay,time, active;
    public Timer timer;
    public GameObject falseBG , trueBg;
    
    void Start()
    {
        
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
        
        if (active > time)
            {
            falseBG.SetActive(false);
            trueBg.SetActive(true);
            }
    }
}
