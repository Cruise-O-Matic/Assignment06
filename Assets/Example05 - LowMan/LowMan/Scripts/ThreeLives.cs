using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEditor;

public class ThreeLives : MonoBehaviour
{
    public static int lives = 3;
    public Text lifeText;
    public GameObject player;
    public GameObject enemy;
    public Text scoreInput;

    public void InputPlayerScores()
    {
        string path = "Assets/scores.txt";
        scoreInput.text = Score.CurrentScore.ToString();

        string scoreCount = scoreInput.text;
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(scoreCount);
        writer.Close();
        AssetDatabase.ImportAsset(path);
        TextAsset asset = (TextAsset)Resources.Load("scores");
        
    }

    public void loseLife()
    {
        lives--;
        if (lives == 0)
        {
            InputPlayerScores();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            lives = 3;
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        string tag = col.tag;

        switch (tag)
        {
            case "Enemy":
                loseLife();
                lifeText.text = lives.ToString();
                player.transform.position = new Vector3(-9.3f, 0.54f, -4.94f);
                enemy.transform.position = new Vector3(8.77f, 1.53f, 9.52f);
                break;
        }
    }
}