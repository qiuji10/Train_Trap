using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeValue = 180;
    public bool levelEnd;
    private int pdc;

    public Text timeText;
    public GameObject crossFade, bomb, objectiveHint;
    public GameSceneManager gsm;
    [SerializeField] private GameObject cam;
    [SerializeField] AudioData Explosion0;

    void Awake()
    {
        gsm = GetComponent<GameSceneManager>();
        pdc = PlayerPrefs.GetInt("PlayerDieCount");
        if (pdc == 0)
        {
            timeValue = 60;
            objectiveHint.SetActive(false);
        }
    }

    void Update()
    {
        if(timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            AudioManager.instance.PlaySFX(Explosion0, "Explosion0");
            timeValue = 0;
            GameOver();
        }

        if (pdc != 0)
            DisplayTime(timeValue);
        else
            return;
    }

    public void GameOver()
    {
        crossFade.SetActive(true);
        bomb.SetActive(true);
        StartCoroutine(StartGameOver());
    }

    IEnumerator StartGameOver()
    {
        yield return StartCoroutine(cam.GetComponent<CameraFollow>().ShakeScreen(1f, 0.7f));
        if (!levelEnd)
            yield return StartCoroutine(SwitchGameOver());
        else
            yield return StartCoroutine(SwitchWin());
    }

    IEnumerator SwitchGameOver()
    {
        yield return new WaitForSeconds(1f);
        gsm.SwitchScene(1);
    }

    IEnumerator SwitchWin()
    {
        yield return new WaitForSeconds(1f);
        gsm.SwitchScene(4);
    }

    void DisplayTime(float timeToDisplay) 
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        else if (timeToDisplay > 0)
        {
            timeToDisplay++;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
