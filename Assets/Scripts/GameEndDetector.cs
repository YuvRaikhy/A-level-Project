using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndDetector : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) // Checks collision between gameobjects and GameEnd trigger
    {
        if (other.gameObject.name == "selectedcharacter") // If the GameObject is the player 
        {
            SceneManager.LoadScene(5); /*/ Loads End Game Scene /*/
        }
    }
}
