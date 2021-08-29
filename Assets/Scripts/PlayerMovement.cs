using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.4f;
    public AudioClip deathClip;
    //hitboxes
    public GameObject topLeft;
    public GameObject bottomRight;
    // Global variables for accessor
    public bool playerhit = false;
    // Accessor varibles
    bool gameover = false;

    void Update()
    {
        // Accessor Variables
        gameover = GameObject.Find("Player").GetComponent<PlayerMovement>().playerhit;

        // Move character
        if (!gameover)
        {
            // move character if still on screen
            if (Input.GetKey(KeyCode.UpArrow) && topLeft.transform.position.y < 0.3f)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.DownArrow) && bottomRight.transform.position.y > -0.2f)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.LeftArrow) && topLeft.transform.position.x > -0.4f)
            {
                transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            }

            if (Input.GetKey(KeyCode.RightArrow) && bottomRight.transform.position.x < 0.4f)
            {
                transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            }
        }

        // Animations when game is over
        if (gameover)
        {
            Animation anim = gameObject.GetComponent<Animation>();
            anim.Play("playerDeath");
            // Restart the level
            StartCoroutine(gameoverHandler());
        }
    }

    // If player gets hit by fire
    private void OnTriggerEnter2D(Collider2D collider)
    {
        playerhit = true;    
        Vector2 soundPosition = new Vector2(0, 0);    
        // Play Audio
        AudioSource.PlayClipAtPoint(deathClip, soundPosition);
    }

    IEnumerator gameoverHandler()
    {
        yield return new WaitForSeconds(3);

        // Reset Globals
        playerhit = false;
        speed = 0.4f;
        GameObject.Find("Player").GetComponent<PlayerMovement>().playerhit = true;

        // Restart Scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title Screen");
    }
}
