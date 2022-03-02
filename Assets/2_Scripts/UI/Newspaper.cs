using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Newspaper : MonoBehaviour
{
    public GameObject NewsPanel;
    

    public void OpenPanel()
    {
        Instantiate(NewsPanel, transform.parent.parent.parent, false);
        
        if (NewsPanel != null)
        {

            bool isActive = NewsPanel.activeSelf;
            NewsPanel.SetActive(isActive);

            Debug.Log("working");
        }
    }

    public void DestroyPanel()
    {
        Destroy(NewsPanel);
    }

}
