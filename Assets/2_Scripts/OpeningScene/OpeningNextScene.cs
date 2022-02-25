using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningNextScene : MonoBehaviour
{
    private void OnEnable()
    {
        
        SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
    }
}
