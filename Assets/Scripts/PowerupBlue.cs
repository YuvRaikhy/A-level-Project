using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBlue : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision) // Triggers when there is collision between power-up and another gameobject
    {
        if (collision.gameObject.name == "selectedcharacter") // If the gameobject is the player
        {
            EnemyPathfinding.instance.speed = EnemyPathfinding.instance.speed / 2; // The enemy speed decrease by 50%
            Destroy(gameObject); // Destroys the gameobject
        }
        else if (collision.gameObject.name == "Enemy1(Clone)" || collision.gameObject.name == "Enemy1 Variant(Clone)") // If the gameobject is the enemy
        {
            Destroy(gameObject); // Destroys the gameobject
        }
    }
}
