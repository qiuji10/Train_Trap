using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text countText;
    private int playerDieCount;

    private void Start()
    {
        playerDieCount = PlayerPrefs.GetInt("PlayerDieCount");
        playerDieCount += 1;
        PlayerPrefs.SetInt("PlayerDieCount", playerDieCount);
        countText.text = playerDieCount.ToString();
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
