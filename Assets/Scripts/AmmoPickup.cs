using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    private int ammoAmt = 10;
    
    void OnTriggerEnter(Collider other)
    {
        // Checks to see if the object collided with is a pickup item before collecting it
        if (other.gameObject.tag == "Ammo")
        {
            Gun.ammo += (Gun.ammo+ammoAmt > Gun.maxAmmo) ? 
                (Gun.maxAmmo - Gun.ammo) : ammoAmt;
            Destroy(other.gameObject);
        }
    }
}
