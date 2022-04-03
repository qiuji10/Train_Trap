using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;
using System.Linq;

public class Ending : MonoBehaviour
{
    public bool isTriggered;

    public UnityEvent ChangeDialogue;
    Collected collected;
    DialogueManager dm;

    private void Awake()
    {
        UpdateData();
        dm = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {
        if (isTriggered && Input.GetKeyDown(KeyCode.E) && Check())
        {
            //haven't add anything yet, later do switch scene
            //extend time, hide time, wait until dialogue finish, switch to win screen
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
        yield return null;
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
