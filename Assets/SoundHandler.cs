using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    private AudioSource[] mysounds;

    private AudioSource pickUp;

    // Start is called before the first frame update
    void Start()
    {
        mysounds = GetComponents<AudioSource>();

        pickUp = mysounds[0];
    }

    public void PlayPickUp()
    {
        pickUp.Play();
    }
}
