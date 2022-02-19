using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public Text nameText;
    public Text dialogueText;
    public GameObject dialogueBox;
    public GameObject slot;
    public bool isInteracted = false;

    private Queue<string> sentences;

    void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    void Start()
    {
        sentences = new Queue<string>();
        var list = sentences.ToList();
    }

    public void StartDialogue(Dialogue dialogue) 
    {
        isInteracted = true;
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        dialogueBox.SetActive(true);
        slot.SetActive(false);
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        
        DisplayNextSentence();
    }

    public void DisplayNextSentence() 
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            dialogueBox.SetActive(false);
            slot.SetActive(true);
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
        isInteracted = false;
        Debug.Log("there is no sentences alr");
    }
}
