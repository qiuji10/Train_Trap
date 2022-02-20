using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance;

    void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    public void SwitchScene(int indexBuild)
    {
        SceneManager.LoadScene(indexBuild);
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Game is closed");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Blockout");
    }
}
