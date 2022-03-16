using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition1 : MonoBehaviour
{
    public Transform target;
    public float speed,delay,time, active;
    public Timer timer;
    public GameObject StationBG , GameplayBg;
    
    void Start()
    {
        delay = 170;
        active = 162;
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
            StationBG.SetActive(false);
            GameplayBg.SetActive(true);
            }
    }
}
