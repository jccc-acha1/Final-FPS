using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static float health = 100f;

    // Update is called once per frame
    void Update()
    {
        // Checks the player's health to see if they're dead
        if (health >= 100f)
            health = 100f;
        else if (health <= 0f) 
            Die();
    }

    void Die() {
        // Kill the player
        Debug.Log("Dead Player");
        Destroy(gameObject);
    }
}
