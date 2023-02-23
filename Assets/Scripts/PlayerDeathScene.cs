using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathScene : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(3);
        Stopwatch.theTime = 0;
    }

    public void RTMM()
    {
        SceneManager.LoadScene(0);
        Stopwatch.theTime = 0;
    }
}
