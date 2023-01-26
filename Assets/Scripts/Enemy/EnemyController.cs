using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public LayerMask groundLayer;
    public LayerMask playerLayer;

    //Patroling
    private Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //States
    public float sightRange;
    public bool playerInSightRange;
    public bool chasePlayer;

    //Cooldown before stopping chasing
    private float cooldown = 2f;

    private NavMeshAgent agent;
    private Transform player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //Check for sight
        if (CheckForPlayer()) playerInSightRange = true;
        else playerInSightRange = false;

        if (!playerInSightRange && !chasePlayer) Patroling();
        if (playerInSightRange) chasePlayer = true;
        if (chasePlayer) ChasePlayer();
        /*if (playerInAttackRange && playerInSightRange) AttackPlayer();*/
    }

    bool CheckForPlayer()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(-0.5f, 0, 1f)), sightRange / 1.35f, playerLayer) ||
            Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(-0.25f, 0, 1f)), sightRange / 1.15f, playerLayer) ||
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), sightRange, playerLayer) ||
            Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(0.25f, 0, 1f)), sightRange / 1.15f, playerLayer) ||
            Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(0.5f, 0, 1f)), sightRange / 1.35f, playerLayer))
        {
            return true;
        }
        else return false;
    }

    void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet) agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f) walkPointSet = false;
    }

    void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
         
        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundLayer)) walkPointSet = true;
    }

    void ChasePlayer()
    {
        if(!playerInSightRange)
        {
            if (cooldown <= 0)
            {
                chasePlayer = false;
                cooldown = 2f;
            }
            else cooldown -= Time.deltaTime;
        }

        agent.SetDestination(player.position);
    }
}
