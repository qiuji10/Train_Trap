using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GuardPatrol : MonoBehaviour
{
    public List<Transform> points;
    public int nextId;
    int idChangeValue = 1;
    public bool playerinRange;
    float WalkSpeed = 2;
    public Locker playerUseKeypadLocker;
    public PryOpenLocker playerUseLocker;
    public PryOpenLocker PlayerUseLocker2;
    public PryOpenLocker PlayerUseLocker3;
    public bool isFacingLeft;
    // Start is called before the first frame update
   
    GuardPatrol gp;
    NpcInteraction npcInteract1;
    public UnityEvent  getCaught;
    public GameObject player, crossFade;
    DialogueManager dm;
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        dm = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }
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

        if (playerinRange && (playerUseKeypadLocker.usingLocker ||  playerUseLocker.usingLocker2 || PlayerUseLocker2.usingLocker2 || PlayerUseLocker3.usingLocker2 == true))
        {
            Debug.Log("Catch Player");
            StartCoroutine(getcCaught());
        }
    }  

    void Patrol()
    {
        Transform goalPoint = points[nextId];
        if (goalPoint.transform.position.x > transform.position.x)
        {
            Debug.Log("FLIP");
            anim.SetBool("walkright",true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            Debug.Log("left");
            anim.SetBool("walkright", false);
            transform.localScale = new Vector3(-1, 1, 1);
        }

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

    private IEnumerator getcCaught()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        WalkSpeed = 0;
        dm.dialogueText.text = "HEYYYYYYY!!!!!!! YOu THEREEEE";
        dm.nameText.text = "MAn Guard";
        

        yield return new WaitForSeconds(1f);
        dm.dialogueBox.SetActive(true);
        //cutscene animation
        yield return new WaitForSeconds(3f);
        crossFade.SetActive(true);
        yield return new WaitForSeconds(2f);
        
        player.transform.position = new Vector3(16.5f, player.transform.position.y, player.transform.position.z);
        dm.dialogueBox.SetActive(false);
        dm.slot.SetActive(true);
 

        yield return new WaitForSeconds(1f);
        crossFade.SetActive(false);
        WalkSpeed = 2;
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
        
        
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
