using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Linq;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] Text tenScores;
    public Text yourScore;

    string[] tenScoresArray = new string[10];
    string myFilePath, fileName;

    int i;

    void Start()
    {
        fileName = "scores.txt";
        myFilePath = Application.dataPath + "/" + fileName;
        ReadFromTheFile();
        yourScore.text = Score.CurrentScore.ToString();
    }

    void DisplayAllScores()
    {
        System.Array.Sort(tenScoresArray);
        Array.Reverse(tenScoresArray);
        foreach (string line in tenScoresArray)
        {
            tenScores.text += line + "\n";
        }

    }

    public void ReadFromTheFile()
    {
        tenScoresArray = File.ReadAllLines(myFilePath);
        DisplayAllScores();
    }
}
