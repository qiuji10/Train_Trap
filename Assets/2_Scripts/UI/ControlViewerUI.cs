using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlViewerUI : MonoBehaviour
{
    [SerializeField] GameObject E, R, F;

    void Update()
    {
        if (PlayerCore.instance.KeyE)
            E.SetActive(true);
        else
            E.SetActive(false);

        if (PlayerCore.instance.KeyR)
            R.SetActive(true);
        else
            R.SetActive(false);

        if (PlayerCore.instance.KeyF)
            F.SetActive(true);
        else
            F.SetActive(false);
    }
}
