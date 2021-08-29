using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{
    public AudioClip clickSound;

    public void startGame ()
    {
        StartCoroutine(transition());
    }

    IEnumerator transition ()
    {
        // Play Audio
        AudioSource.PlayClipAtPoint(clickSound, transform.position);
        // Wait
        yield return new WaitForSeconds(0.5f);
        // Load Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  

    }
}

