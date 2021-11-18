using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTank : MonoBehaviour {
    NavMeshAgent agent;
    [SerializeField] Transform player;
    public LayerMask groundMask, playerMask;
    public GameObject projectile;
    public Transform shootPoint;
    public int health = 20;

    //Patroling
    public Vector3 walkpoint;
    bool walkPointSet;
    public float walkPointRange = 100f;
    //Attacking
    public float timeBetweenAttacks =1;
    bool alreadyAttacked = false;
    //States
    public float sightRange = 35, attackRange = 24;
    bool playerInSightRange, playerInAttackRange;

    private void Awake() {
        player = FindObjectOfType<PlayerTank>().transform;
        agent = GetComponent<NavMeshAgent>();
    }

void Update() {

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerMask);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerMask);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    void Patroling() {
        if (!walkPointSet) { SearchWalkPoint(); }

        if (walkPointSet) {
            LookAtTarget();
            agent.SetDestination(walkpoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkpoint;
        if (distanceToWalkPoint.magnitude < 1f) {
            walkPointSet = false;
        }
    }

    void LookAtTarget() {
        Vector3 direction = (walkpoint - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

    void ChasePlayer() {
        agent.SetDestination(player.position);
    }

    void AttackPlayer() {
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        if (!alreadyAttacked) {
            // Attack code here
            Rigidbody rigidbody = Instantiate(projectile, shootPoint.position, shootPoint.rotation).GetComponent<Rigidbody>();
            rigidbody.AddForce(transform.forward * 32f, ForceMode.Impulse);
            alreadyAttacked = true;

            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    void ResetAttack() {
        alreadyAttacked = false;
    }
    private void SearchWalkPoint() {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkpoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkpoint, -transform.up, 2f, groundMask)) {
            walkPointSet = true;
        }
    }

    public void Damage(int damage) {
        health -= damage;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.gameObject.CompareTag("Missile")) {
            //Debug.Log("MISSILE....");
            Damage(10);
            if (health <= 0) {
                Destroy(gameObject);
            }
        }
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, walkPointRange);
    }
}
