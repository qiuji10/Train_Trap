using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaryPic : MonoBehaviour
{
    public GameObject MaryPanel;

    public void OpenPanel()
    {
        Instantiate(MaryPanel, transform.parent.parent.parent, false);

        if (MaryPanel != null)
        {

            bool isActive = MaryPanel.activeSelf;
            MaryPanel.SetActive(isActive);

            Debug.Log("working");
        }
    }

    public void DestroyPanel()
    {
        Destroy(MaryPanel);
        //DestroyImmediate(MaryPanel, true);
    }
}
