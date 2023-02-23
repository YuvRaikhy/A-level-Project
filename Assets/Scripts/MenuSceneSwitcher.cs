using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneSwitcher : MonoBehaviour
{
   public void PlayButton()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
    }

    public void CharacterMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
