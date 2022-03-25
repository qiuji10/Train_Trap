using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MainMenu : MonoBehaviour
{
    public Button continueButton;
    public TextAsset booleanJson;
    public GameObject SliderBar;
    public Slider slider;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("PlayerDieCount") == 0)
            continueButton.interactable = false;
        else
            continueButton.interactable = true;
        slider = SliderBar.GetComponent<Slider>();
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Game is closed");
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("PlayerDieCount", 0);
        PlayerPrefs.SetInt("GetAllClues", 0);
        Collected collected = JsonUtility.FromJson<Collected>(booleanJson.text);
        int num = 0;
        foreach (int clue in collected.collectedClue.ToArray())
        {
            collected.collectedClue[num] = 0;
            num++;
        }
        string json = JsonUtility.ToJson(collected);
        File.WriteAllText(Application.dataPath + "/Resources/clueBool.json", booleanJson.text);
        GameSceneManager.instance.SwitchScene(2);
    }

    public void ContinueGame()
    {
        if (PlayerPrefs.GetInt("PlayerDieCount") != 0)
            GameSceneManager.instance.SwitchScene(3);
        else
            return;
    }

    public void AdjustVolume()
    {
        PlayerPrefs.SetFloat("Volume", slider.value);
        AudioListener.volume = PlayerPrefs.GetFloat("Volume");
    }
}
