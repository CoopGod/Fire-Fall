using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class highscoreHandler : MonoBehaviour
{
    public Text highscoreBox;

    void Awake()
    {
        Debug.Log(PlayerPrefs.GetFloat("highscore", 0));
        highscoreBox.text = PlayerPrefs.GetFloat("highscore").ToString("F");
    }
}
