using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleFade : MonoBehaviour
{
    public float speed = 0.2f;

    void Update()
    {
        // Move title off screen 
        if (Time.time > 3.0f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }
    }
}
