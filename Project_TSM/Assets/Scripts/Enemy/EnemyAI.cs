using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;


    string playerTag = "Player";

    private void Awake()
    {
        player = GameObject.FindWithTag(playerTag).transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check if player in sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        //Patrol if player is not in sight and attack range
        if(!playerInSightRange && !playerInAttackRange)
        {
            Patroling();
        }

        //if player in sight but not in attack, start chasing
        if (playerInSightRange && !playerInAttackRange)
        {
            Chase();
        }

        //if player in sight and attack range, start attacking
        if(playerInAttackRange && playerInSightRange)
        {
            Attack();
        }
    }

    void Patroling()
    {
        //search walk point
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        //move to walk point
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
            Debug.Log("Patroling");
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if(distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }   
    }

    void Chase()
    {
        Debug.Log("Chasing");
        agent.SetDestination(player.position);
    }

    void Attack()
    {
        Debug.Log("Attacking");
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }


    void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
