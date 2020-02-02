using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeightSlider : MonoBehaviour
{
    private Slider slider;
    public Transform height;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
    }

    void Update()
    {
        slider.value = height.position.y / 100;
    }
}
