using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnImpact : MonoBehaviour
{
    public float damage = 20f;

    void OnTriggerEnter(Collider collision) {
        // Checks if damage is being dealt to the player or an enemy and applies said damage

        if (collision.gameObject.tag == "Player") {
            PlayerHealth.health -= damage;
            Debug.Log($"Player Health: {PlayerHealth.health}");
        } else if (collision.gameObject.tag == "Enemy") {
        } else {
            Destroy(gameObject);
        }
    }
}
