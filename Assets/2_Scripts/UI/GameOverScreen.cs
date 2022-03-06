using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text countText;
    private int playerDieCount;

    private void Awake()
    {
        playerDieCount = PlayerPrefs.GetInt("PlayerDieCount");
        playerDieCount++;
        countText.text = playerDieCount.ToString();
        PlayerPrefs.SetInt("PlayerDieCount", playerDieCount);
    }

    public void ReviveButton()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
