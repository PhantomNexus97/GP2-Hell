using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms.Impl;

public class AiTest : MonoBehaviour
{
    public UnitHealthSystem _enemyHealth = new UnitHealthSystem(100, 100);

    public NavMeshAgent agent;

    public Transform _player;

    public LayerMask whatIsGround, whatIsPlayer;

    public GameManager gameManager;

    //Patrol
    //public Transform _hubPoint;
    public Transform[] waypoints;
    //private int _waypointIndex;
    private float _dist;


    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttack;
    //public ProjectileController bullet;
    public Transform firePoint;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        _player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        //_waypointIndex= 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Check Sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patrol();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();

    }
    private void Patrol()
    {

    }

    private void ChasePlayer()
    {
        agent.SetDestination(_player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(_player);
        if (!alreadyAttack)
        {
           // ProjectileController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            alreadyAttack = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttack = false;
    }



    public void TakeDamage(int dmg)
    {
        _enemyHealth.DmgUnit(dmg);

        if (_enemyHealth.Health <= 0) Invoke(nameof(DestroyEnemy), 0.05f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
