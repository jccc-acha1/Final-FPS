using UnityEngine;

public class Gun : MonoBehaviour
{
    private float timerShots;
    public float damage = 10f; // Damage caused to enemy hit.
    public static int ammo = 30; // Ammo the gun starts with.
    public static int maxAmmo = 30; // Max ammo

    public Camera cam; // Camera the gun is attached to.
    public GameObject Bullet; // Gun's bullet
    
    public float Force = 2000f;

    // Update is called once per frame
    void Update()
    {
        GameObject Gun = GameObject.Find("Gun");

        if (Input.GetButtonDown("Fire1") && ammo > 0) // Press left click to fire gun.
        {
            Shoot();

            ammo -= 1; 
        }
    }

    void Shoot() // Shoot following ray
    {
        GameObject BulletHolder;
        BulletHolder = Instantiate(Bullet, transform.position, transform.rotation) as GameObject;
        BulletHolder.transform.Rotate(Vector3.left * 90);
        

        Rigidbody Temp_RigidBody;
        Temp_RigidBody = BulletHolder.GetComponent<Rigidbody>();

        Temp_RigidBody.AddForce(transform.forward * Force);

        Destroy(BulletHolder, 2.0f);
    }
}
