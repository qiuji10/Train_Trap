using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clues : MonoBehaviour
{
    public GameObject CluePanel;

    [SerializeField] AudioData DiaryAudio;

    private void Awake()
    {
        CluePanel = GameObject.Find("CluePanel");
    }

    public void OpenPanel()
    {
        //Instantiate(CluePanel, transform.parent, false);

        //if (CluePanel != null)
        //{
        //    bool isActive = CluePanel.activeSelf;
        //    CluePanel.SetActive(isActive); 
        //}
        CluePanel.SetActive(true);
    }

    public void DestroyPanel()
    {
        CluePanel.SetActive(false);
        //Destroy(CluePanel);
    }

    public void PlayAudio()
    {
        AudioManager.instance.PlaySFX(DiaryAudio, "Diary");
    }
}
