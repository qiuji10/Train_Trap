using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombLocation : MonoBehaviour
{
    public bool isInRange = false;
    public bool hasTool = false;
    public float setTimer = 5f;
    private float holdTimer;
    private int i = 0;

    public GameObject toolbox;
    public GameObject defuseBar;
    public Slider db;

    void Awake()
    {
        db = defuseBar.GetComponent<Slider>();
        db.maxValue = setTimer;
    }

    // Update is called once per frame
    void Update()
    {
        checkItem(i);
        if (isInRange && hasTool && Input.GetKey(KeyCode.E))
        {
            defuseBar.SetActive(true);
            holdTimer -= Time.deltaTime;
            db.value = holdTimer;
            if (holdTimer < 0)
            {
                PlayerCore.instance.inventoryName.RemoveAt(i);
                GameSceneManager.instance.SwitchScene(3);
            }
        }
        else
        {
          
            holdTimer = setTimer;
            db.value = setTimer;
            
        }
        
            
    }

    void checkItem(int loop)
    {
        foreach (string item in PlayerCore.instance.inventoryName)
        {
            if (item == "toolbox")
            {
                hasTool = true;
                break;
            }
            loop++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player is in Range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player is not in Range");
            defuseBar.SetActive(false);

        }
    }
}
