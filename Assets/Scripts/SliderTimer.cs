﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimer : MonoBehaviour
{
    private Slider slTimer;
    float success;
    // Start is called before the first frame update
    void Start()
    {
        slTimer = GetComponent<Slider>();

    }

    // Update is called once per frame
    void Update()
    {
        if(slTimer.value>0.0f)
        {
            slTimer.value -= 0.05f * Time.deltaTime;
            success = GameObject.Find("Image_line").GetComponent<RhythmBar>().success;
            slTimer.value += success;
        }else
        {
            Debug.Log("Timeup!");
        }
        
    }
}