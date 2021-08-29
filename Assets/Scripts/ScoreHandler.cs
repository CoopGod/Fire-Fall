using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreHandler : MonoBehaviour
{
    // Text
    public GameObject score;
    // gameover check
    bool gameover = false;
    bool gameoverCalled = false;

    void Update()
    {
        // Accessor Variables
        gameover = GameObject.Find("Player").GetComponent<PlayerMovement>().playerhit;
        if (gameover)
        {
            // If functions hasn't already been called
            if (!gameoverCalled)
            {
                // Update text to display time alive
                float timeAliveRaw = Time.timeSinceLevelLoad;
                string timeAlive = timeAliveRaw.ToString("F");
                score.GetComponent<Text>().text = timeAlive;
                // Assign PlayerPrefs if beaten highscore
                Debug.Log(timeAliveRaw);
                Debug.Log(PlayerPrefs.GetFloat("highscore"));
                if (PlayerPrefs.GetFloat("highscore") < timeAliveRaw)
                {
                    PlayerPrefs.SetFloat("highscore", timeAliveRaw);
                    Debug.Log("test");
                }
                gameoverCalled = true;
            }
        }
    }
}
