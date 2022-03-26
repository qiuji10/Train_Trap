using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMaryPicClue : MonoBehaviour
{
    public bool isInRange;

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            PlayerPrefs.SetInt("GetMaryPic", 1);
            PlayerCore.instance.ChangeClueData(2);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }
}
