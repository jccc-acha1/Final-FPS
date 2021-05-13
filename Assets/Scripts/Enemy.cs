using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f; // Enemy health

    // Update is called once per frame
    void Update()
    {
        // Checks the enemies health to see if they're dead
        if (health >= 100f)
            health = 100f;
        else if (health <= 0f) 
            Die();
    }

    void Hit(int damage) {
        Debug.Log($"Enemy Health: {health}");
        health -= damage;
    }

    void Die() // Kill enemy
    {
        Destroy(gameObject);
    }
}
