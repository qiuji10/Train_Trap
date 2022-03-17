using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombLocation : MonoBehaviour
{
    public bool isInRange = false;
    public bool hasTool = false;
    public bool isCreated;
    public float setTimer = 5f;
    private float holdTimer;
    private int i = 0;
    private int j;

    public GameObject toolbox;
    public GameObject defuseBar, MaryPic;
    public Slider db;
    Timer timerOBJ;
   

    void Awake()
    {
        timerOBJ = GameObject.Find("TimerText").GetComponent<Timer>();
        db = defuseBar.GetComponent<Slider>();
        db.maxValue = setTimer;
    }

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
            hasTool = PlayerCore.instance.CheckItem(ref i, "toolbox");

        if (isInRange && hasTool && Input.GetKey(KeyCode.E))
        {
            defuseBar.SetActive(true);
            holdTimer -= Time.deltaTime;
            db.value = holdTimer;
            if (holdTimer < 0)
            {
                //PlayerCore.instance.inventoryName.RemoveAt(i);
                //Instantiate picture of Mary
                if (!isCreated)
                {
                    Instantiate(MaryPic);
                    isCreated = true;
                    //Destroy(defuseBar);
                    timerOBJ.timeValue = 5f;
                    timerOBJ.levelEnd = true;
                }
               
            
            }
        }
        else
        {
            holdTimer = setTimer;
            db.value = setTimer;
        }
    }

    //IEnumerator BombEnd()
    //{
    //    yield return new WaitForSeconds(5);

    //}



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            PlayerCore.instance.KeyE = PlayerCore.instance.CheckItem(ref j, "toolbox");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            PlayerCore.instance.KeyE = false;
            defuseBar.SetActive(false);
        }
    }
}
