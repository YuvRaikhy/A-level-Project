using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollisions : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "selectedcharacter")
        {
            SceneManager.LoadScene(2);
        } 
    }
}
