using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyPathfinding : MonoBehaviour
{

    public static EnemyPathfinding instance;
    private static int poweruptally = 0;
    private static int playertally = 0;

    private GameObject target;
    private GameObject[] targets; // List of the gameobjects (Player, Power-up) from which the target is selected
    public float nextWaypointDistance = 1f;
    public float speed;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    // Start function is called before the first frame update
    void Start() // Calls all relevant methods at the start of the level
    {
        instance = this;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        ChangeSpeed(); // Changes the speed of the enemy based on tally at the start of the level.
        ChangeTally(); // Changes tally at the start of the level

        InvokeRepeating("FindClosestTarget", 0f, 0.5f); // Repeats every 0.5 seconds to find which is closer the player or the power-up
        InvokeRepeating("UpdatePath", 0f, .5f); // Repeats every 0.5 seconds to update path to the designated target
    }

    void FindClosestTarget() // This method is responsible for finding the closer target player or power-up
    {
        if (GameObject.Find("Powerup-Blue(Clone)") != null) // Checks if power-up exists
        {
            targets = GameObject.FindGameObjectsWithTag("Targets"); // Adds powerup to target list
            float distance = Mathf.Infinity;  
            Vector3 position = transform.position;
            foreach (GameObject t in targets)  // Loops through each of the target in the targets list and works out the distance between enemy and target
            {
                Vector3 diff = t.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    target = t;
                    distance = curDistance;
                }
            }
        } else
        {
            target = GameObject.Find("selectedcharacter");
        }
    }

    void ChangeTally() // Changes tally based on which gameobejct is closer.
    {
        if (target == GameObject.Find("Powerup-Blue(Clone)")) 
        {
            playertally += 1;
        }
        else
        {
            poweruptally += 1;
        }
        Debug.Log("Powerup Tally: " + poweruptally);
        Debug.Log("Player Tally: " + playertally);
    }

    void ChangeSpeed() // Changes speed based on the tally
    {
        if (poweruptally > playertally)
        {
            speed = speed / 2;
        }
        else if (playertally > poweruptally)
        {
            speed = speed * 2;
        }
        else
        {
            Debug.Log("Same old!");
        }
    }

    void UpdatePath() // Updates teh path to the path to the target
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.transform.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p) // Checks if a path is completed
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    public void FixedUpdate() // Responsible for moving the enemyevery frame towards th target
    {

        if (path == null)
        {
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count) 
        {
            reachedEndOfPath = true;
            return;
        } else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized; // Direction towards teh target
        Vector2 force = direction * speed * Time.deltaTime; // Force that needs to be applied to move the enemy towards that direction

        rb.AddForce(force); // Adds force, moves teh enemy with the force.

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
}