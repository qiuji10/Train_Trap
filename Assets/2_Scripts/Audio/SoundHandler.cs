using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    public AudioSource[] mysounds;

    public AudioSource pickUp;

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
