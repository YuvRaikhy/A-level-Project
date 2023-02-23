using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{

    Text text;
    public static float theTime;
    public float speed = 1;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>(); // Gets the text component in the stopwatch gameobject as that is what we will update with the time
    }

    void Update() // Game update
    {
        theTime += Time.deltaTime * speed; // Calculates the time acording to game speed
        string minutes = Mathf.Floor((theTime % 3600) / 60).ToString("00"); // Calculates the minutes and replaces as string instead of "00"
        string seconds = (theTime % 60).ToString("00"); // Calculates the seconds and replaces as string instead of "00"
        string milliseconds = (theTime * 1000).ToString("00"); // Calculates the milliseconds and replaces as string instead of "00"
        text.text = minutes + ":" + seconds + ":" + milliseconds; // Updates "00:00:00" in the text field with the time
    }
}