using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_menu_playerprefs : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.SetInt("PlayerDieCount", 1);
    }
}
