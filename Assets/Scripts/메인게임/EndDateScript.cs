﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndDateScript : MonoBehaviour
{
    public Text dateEnd;
    public int date;

    // Start is called before the first frame update
    void Start()
    {
        dateEnd.text = GameStaticData.data.date.ToString();
        date = GameStaticData.data.date;
    }

    // Update is called once per frame
    void Update()
    {
        if(date != GameStaticData.data.date)
        {
            dateEnd.text = GameStaticData.data.date.ToString();
        }
    }
}
