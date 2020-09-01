﻿/*音量調整スクリプト*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeAdjustment : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    public Slider slider;
    void Start()
    {
        audioSource.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = slider.GetComponent<Slider>().normalizedValue;
    }
}
