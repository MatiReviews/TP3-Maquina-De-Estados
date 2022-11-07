using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask Ground, Player;

    //patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    enum States{
        patroll,
        chase,
        attack,
        die
    }

    States currentState = States.patroll;

    private void Awake(){
        player = GameObject.Find("First Person Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, Player);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, Player);

        if (!playerInSightRange && !playerInAttackRange){
            currentState = States.patroll;
        }
            
        if (playerInSightRange && !playerInAttackRange){
            currentState = States.chase;
        }
        if (playerInAttackRange && playerInSightRange){
            currentState = States.attack;
        }

        checkState();
    }

    public int GetEnemyState(){
        return (int)currentState;
    }

    private void checkState(){
        
        switch (currentState)
        {
            case States.patroll:
                Patrolling();                
                break;
            case States.chase:
                ChasePlayer();              
                break;
            case States.attack:
                AttackPlayer();               
                break;
            case States.die:

                break;
            default:
                break;
        }
    }

    void SearchWalkPoint(){
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, Ground))
        {
            walkPointSet = true;
        }
    }

    private void Patrolling(){
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
      
    private void ChasePlayer(){
        agent.SetDestination(player.position);        
    }

    private void AttackPlayer(){
        //Enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked && playerInAttackRange){

            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);            

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    void ResetAttack(){
        alreadyAttacked = false;
    }




}
