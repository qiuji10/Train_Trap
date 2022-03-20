using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class startCutscene : MonoBehaviour
{
    public PlayableDirector npc7;
    public GameObject player;
    public static bool isCutsceneOn;

    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.tag == "Player")
    //    {           
    //        isCutsceneOn = true;
    //        npc7.Play();
    //        Destroy(gameObject);
    //    }
    //}

    void StopCutscene()
    {
        isCutsceneOn = false;
    }

    IEnumerator FinishCutscene()
    {
        yield return new WaitForSeconds(8);
        player.SetActive(true);

    }
   
}
