using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballMovement : MonoBehaviour
{
    public float startSpeed = 0.1f;
    // Accessor Variables
    bool gameover = false;

    void Start()
    {
        startSpeed = Random.Range(0.15f, 0.4f);
    }

    void Update()
    {
        // Accessor Variables
        gameover = GameObject.Find("Player").GetComponent<PlayerMovement>().playerhit;

        // Move fire
        transform.position = new Vector2(transform.position.x, transform.position.y - ((startSpeed * Time.deltaTime)));

        // When game over remove all objects
        if (gameover)
        {
            Destroy(gameObject);
        }

        // Destroy gameobject if pastthe screen to free memory
        if (transform.position.y < -0.3f)
        {
            Destroy(gameObject);
        }
    }
}
