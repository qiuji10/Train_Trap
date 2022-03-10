using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button continueButton;
    private void Awake()
    {
        if (PlayerPrefs.GetInt("PlayerDieCount") == 0)
            continueButton.interactable = false;
        else
            continueButton.interactable = true;

    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Game is closed");
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("PlayerDieCount", 0);
        GameSceneManager.instance.SwitchScene(2);
    }

    public void ContinueGame()
    {
        if (PlayerPrefs.GetInt("PlayerDieCount") != 0)
            GameSceneManager.instance.SwitchScene(3);
        else
            return;
    }
}
