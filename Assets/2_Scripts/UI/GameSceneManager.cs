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
        Debug.Log(PlayerPrefs.GetInt("PlayerDieCount"));
    }

    public void SwitchScene(int indexBuild)
    {
        SceneManager.LoadScene(indexBuild);
    }
}
