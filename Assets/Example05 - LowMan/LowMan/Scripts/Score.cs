using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int CurrentScore = 0;

    public Text scoreCounter;

    void Start()
    {
        scoreCounter.text = CurrentScore.ToString();
    }
}