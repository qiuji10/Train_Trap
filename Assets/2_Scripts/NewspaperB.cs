using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NewspaperB : MonoBehaviour
{
    

    private void Start()
    {
        PlayerCore.instance.ChangeClueData(4);
    }

    
}
