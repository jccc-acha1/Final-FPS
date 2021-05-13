using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnImpactEn : MonoBehaviour
{
    public float damage = 20f;

    void OnTriggerEnter(Collider collision) {
        // Checks if damage is being dealt to the player or an enemy and applies said damage

        if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.SendMessage("Hit", damage);
        } else if (collision.gameObject.tag == "Player") {
        } else {
            Destroy(gameObject);
        }
    }
}
