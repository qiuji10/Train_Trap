using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimidGuyAHHH : MonoBehaviour
{
    private DialogueManager dm;

    private void Start()
    {
        dm = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();

        dm.nameText.text = "TimidGuy";
        dm.dialogueText.text = "AHHHHHHH !!!";
        StartRun();
        EndRun();
        return;
    }
   
    public void StartRun()
    {
        StartCoroutine(SetDialogueActive());
    }
    public void EndRun()
    {
        StartCoroutine(SetDialogueInactive());
    }

    IEnumerator SetDialogueActive()
    {
        yield return new WaitForSeconds(10f);
        dm.dialogueBox.SetActive(true);

    }
    IEnumerator SetDialogueInactive()
    {
        yield return new WaitForSeconds(18f);
        dm.dialogueBox.SetActive(false);
    }
}
