using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMaryPicClue : MonoBehaviour
{
    private void Start()
    {
        PlayerCore.instance.ChangeClueData(2);
    }
}
