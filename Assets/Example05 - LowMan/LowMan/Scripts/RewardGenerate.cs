using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using System.IO;
using UnityEditor;

public class RewardGenerate : MonoBehaviour
{
    public GameObject newReward;
    private bool canceled = false;

    void SpawnReward()
    {
        float x = Random.Range(-10.0f, 10.0f);
        float y = 1.0f; 
        float z = Random.Range(-10.0f, 10.0f);
        Instantiate(newReward, new Vector3(x, y, z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!canceled)
            {
                CancelInvoke();
                canceled = true;
            }
            else
            {
                Invoke("SpawnReward", 1);
                canceled = false;
            }
        }
    }

    public static void scoreCount()
    {
        Score.CurrentScore += 100;
        Debug.Log("Score: " + Score.CurrentScore);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        scoreCount();
        SpawnReward();
    }
}
