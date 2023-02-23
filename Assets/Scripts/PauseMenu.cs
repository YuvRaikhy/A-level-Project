using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false); // Sets the pause menu panel to be off at the start
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) // Checks if 'Escape' key is pressed
        {
            if (isPaused) // If teh game is already paused
            {
                ResumeGame(); // Calls ResumeGame() method
            }
            else
            {
                PauseGame(); // Calls PauseGame() method
            }
        }
    }

    public void PauseGame() // Responsible for pausing the game
    {
        pauseMenu.SetActive(true); // Activates pausemenu
        Time.timeScale = 0f; // Freezes time
        isPaused = true; // sets isPaused to true
    }

    public void ResumeGame() // Responsible for unpausing the game
    {
        pauseMenu.SetActive(false); // Deactivates pausemenu
        Time.timeScale = 1f; // Unfreezes time
        isPaused = false; // sets isPaused to false
    }

    public void ReturnToMainMenu() // Responsible for the main menu button
    {
        SceneManager.LoadScene(0);
    }

}
