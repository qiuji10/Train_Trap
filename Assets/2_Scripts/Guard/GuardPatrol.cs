using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardPatrol : MonoBehaviour
{
    public List<Transform> points;
    public int nextId;
    int idChangeValue = 1;
    public bool playerinRange;
    public float WalkSpeed = 2;
    public Locker playerUseLocker;
    // Start is called before the first frame update


    private void Reset()
    {
        Init();
    }

    void Init()
    {
                GetComponent<BoxCollider2D>().isTrigger = true;
                GameObject root = new GameObject(name + "_Root");
                root.transform.position = transform.position;
                transform.SetParent(root.transform);
                GameObject waypoints = new GameObject("Waypoint");
                waypoints.transform.SetParent(root.transform);
                waypoints.transform.position = root.transform.position;
                GameObject p1 = new GameObject("Point1"); p1.transform.SetParent(waypoints.transform); p1.transform.position = root.transform.position;
        GameObject p2 = new GameObject("Point2"); p2.transform.SetParent(waypoints.transform); p2.transform.position = root.transform.position;

        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);
    }
    
   
    
    void Update()
    {
            Patrol();
 
        if (playerinRange && playerUseLocker.usingLocker)
        {
            Debug.Log("Catch Player");
        }
    }

    void Patrol()
    {
        Transform goalPoint = points[nextId];
        if (goalPoint.transform.position.x > transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, WalkSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, goalPoint.position) < 0.2f)
        {
            if (nextId == points.Count - 1)
                idChangeValue = -1;
            if (nextId == 0)
                idChangeValue = 1;
            nextId += idChangeValue;
        }
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
