using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{

    private int currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex; // Stores the index value of the current scene
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "selectedcharacter") // If player collides with end level trigger
        {
            SceneManager.LoadScene(currentScene+1); // Loads hte next level by loading scene with the next build index
        }
    }
}
