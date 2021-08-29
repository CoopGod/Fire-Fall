using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    // Sprite
    public GameObject enemy;
    public float timeIteration = 10.0f;
    public float difficultyIncrease = 0.4f;
    public float maxDifficulty = 1.6f;
    Vector2 spawnPos;
    // Timing
    float nextSpawn = 4.0f;
    float difficulty = 0f;
    // Accessor variables
    bool gameover = false;

    void Update()
    {
        // Accessor Variables
        gameover = GameObject.Find("Player").GetComponent<PlayerMovement>().playerhit;

        // Set difficulty
        setDifficulty();

        // If game isn't over spawn fires
        if (!gameover)
        {
            if (Time.timeSinceLevelLoad > nextSpawn) // - difficulty increase
            {
                placeFire();
            }
        }
    }

    void placeFire()
    {
        nextSpawn = Time.timeSinceLevelLoad + 1.75f - difficulty;
        spawnPos = new Vector2(UnityEngine.Random.Range(-0.4f, 0.4f), 0.4f);

        Instantiate(enemy, spawnPos, transform.rotation);
    }

    void setDifficulty()
    {
        if (difficulty < maxDifficulty)
        {
            difficulty = (float)Math.Floor(Time.timeSinceLevelLoad / timeIteration) * difficultyIncrease;
        }
    }
}