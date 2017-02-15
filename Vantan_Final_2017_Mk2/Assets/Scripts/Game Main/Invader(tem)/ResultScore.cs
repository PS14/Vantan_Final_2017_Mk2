﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class ResultScore : MonoBehaviour
{
    public static int SScore;
    public static int MainScore;
    int MemoryScore;
     

    void Start()
    {
        MainScore = 0;
        MainScore = Score.score;
    }


    void Update()
    {
        if (SScore < MainScore)
        {
            SScore += 10;
        }

        //スコア表示
        GetComponent<Text>().text = SScore.ToString();
    }
}
