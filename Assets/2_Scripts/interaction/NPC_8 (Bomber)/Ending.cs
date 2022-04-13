using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public bool isTriggered;

    public UnityEvent ChangeDialogue;
    public GameObject crossfade, objHint;
    Collected collected;
    DialogueManager dm;
    Timer timerObj;
    GameSceneManager gsm;
    Text timerText;

    private void Awake()
    {
        UpdateData();
        timerObj = GameObject.Find("TimerText").GetComponent<Timer>();
        timerText = timerObj.GetComponent<Text>();
        gsm = FindObjectOfType<GameSceneManager>();
        dm = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {
        if (isTriggered && Input.GetKeyDown(KeyCode.E) && Check())
        {
            //extend time, hide time, wait until dialogue finish, switch to win screen
            timerObj.timeValue = 2000f;
            timerText.enabled = false;
            objHint.SetActive(false);
            if (!dm.dialogueBox.activeInHierarchy)
            {
                EnterEnding();
            }
        }
    }

    bool Check()
    {
        foreach (int collect in collected.collectedClue)
        {
            if (collect == 0)
                return false;
        }
        return true;
    }

    void ChangeToEndingDialogue()
    {
        ChangeDialogue.Invoke();
    }

    void UpdateData()
    {
        string cluesText = File.ReadAllText(Application.dataPath + "/Resources/clueBool.json");
        collected = JsonUtility.FromJson<Collected>(cluesText);
    }

    void EnterEnding()
    {
        StartCoroutine(Endgame());
    }

    IEnumerator Endgame()
    {
        Debug.Log("Activate Crossfade, Switch Scene to Win");
        crossfade.SetActive(true);
        yield return new WaitForSeconds(1);
        gsm.SwitchScene(4);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UpdateData();

            if (Check())
            {
                ChangeToEndingDialogue();
                isTriggered = true;
            }
            
        }
    }
}
