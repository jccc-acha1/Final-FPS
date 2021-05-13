using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask groundLayer, playerLayer;
    public GameObject Bullet;

    public float timeBetweenAttacks;
    bool alreadyAttacked;
    
    // States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    // Shot timing
    private float timerShots;
    public float timeBtwShots = 0.25f;
    public float fireRadius = 25f;
    public float Force = 2000f;

    private void Awake() {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Idle() {
        // Do Nothing
    }
    private void ChasePlayer() { // Chase player
        agent.SetDestination(player.position);
    }
    private void AttackPlayer() { // Attack player (currently with shooting)
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked) { // attack debounce
            // Attack code
            RaycastHit hitPlayer;
            Ray playerPos =  new Ray(transform.position, transform.forward);

            if (Physics.SphereCast(playerPos, 0.25f, out hitPlayer, fireRadius)) { 
                if (Mathf.Floor(timerShots) <= 0 && hitPlayer.transform.tag == "Player") { // Player in range, shoot
                    GameObject BulletHolder;
                    BulletHolder = Instantiate(Bullet, transform.position, transform.rotation) as GameObject;
                    BulletHolder.transform.Rotate(Vector3.left * 90);
                    

                    Rigidbody Temp_RigidBody;
                    Temp_RigidBody = BulletHolder.GetComponent<Rigidbody>();

                    Temp_RigidBody.AddForce(transform.forward * Force);

                    Destroy(BulletHolder, 2.0f);
                    timerShots =  timeBtwShots;
                } else {
                    timerShots -= Time.deltaTime;
                }
            }

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack() {
        // Resets the enemy's attack method
        alreadyAttacked = false;
    }

    // Update is called once per frame
    void Update()
    {
       // Check for sight and attack range
       playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
       playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

       if (!playerInSightRange && !playerInAttackRange) Idle();
       if (playerInSightRange && !playerInAttackRange) ChasePlayer();
       if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }
}
