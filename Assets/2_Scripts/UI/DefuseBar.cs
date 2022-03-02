using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefuseBar : MonoBehaviour
{
    private Slider slider;

    public float FillSpeed = 0.5f;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    void Update()
    {
        slider.value += FillSpeed = Time.deltaTime;
    }

}
