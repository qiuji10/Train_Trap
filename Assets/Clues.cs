using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clues : MonoBehaviour
{
    public GameObject CluePanel;

    public void OpenPanel()
    {
        Instantiate(CluePanel, transform.parent, false);

        if (CluePanel != null)
        {

            bool isActive = CluePanel.activeSelf;
            CluePanel.SetActive(isActive);

            Debug.Log("working");
        }
    }

    public void DestroyPanel()
    {
        Destroy(CluePanel);
    }
}
