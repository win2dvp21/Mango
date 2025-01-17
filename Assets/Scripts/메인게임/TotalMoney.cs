﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalMoney : MonoBehaviour
{
    public static int plusMoney = 0;

    public static int totalMoney = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (RhythmBar.success_count == 18)
        {
            plusMoney = 500;
        }

        else if (RhythmBar.success_count >= 15 && RhythmBar.success_count <= 17)
        {
            plusMoney = 300;
        }

        else if (RhythmBar.success_count >= 12 && RhythmBar.success_count <= 14)
        {
            plusMoney = 200;
        }

        else if (RhythmBar.success_count >= 9 && RhythmBar.success_count <= 11)
        {
            plusMoney = 100;
        }

        else if (RhythmBar.success_count >= 1 && RhythmBar.success_count <= 8)
        {
            plusMoney = 50;
        }

        else
        {
            plusMoney = 0;
        }

        totalMoney += plusMoney;
    }
}
