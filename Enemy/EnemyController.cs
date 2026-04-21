using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
* EnemyController class to handle enemy movement and all logic
*/
public class EnemyController : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] private GameObject EnemyModel;
    [SerializeField] public float EnemyHealth = 100f;
    [SerializeField] public float EnemyStrenght = 10f;
    private bool canMove = true;
    private bool enemyCanTakeDamage = true;
    private bool died = false;

    [Header("Controllers")]
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private QuestController questController;
    [SerializeField] private PlayerHealthManager playerHealthManager;
    [SerializeField] private EnemyAttacks enemyAttacks;

    [SerializeField] private Animator animator;

    [Header("Objects")]
    [SerializeField] private GameObject activeQuest;

    [Header("AI")]
    public UnityEngine.AI.NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    // Patrol
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    // Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    /**
    * Update method handling the statuses in which enemy is based on conditions
    * @return void
    */
    void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();

        if (EnemyHealth <= 0f)
        {   
            canMove = false;
            animator.SetTrigger("died");
            //questController.QuestCompleted();
            StartCoroutine(EnemyDestruction());
        }
    }

    /**
    * SearchWalkPoint method handling the destruction of enemy gameObject after waiting
    * @return void
    */
    IEnumerator EnemyDestruction()
    {
        yield return new WaitForSeconds(5);
        playerStats.PlayerXP += 1;
        Destroy(EnemyModel);
    }

    /**
    * SearchWalkPoint method for patroling if conditions are met
    * @return void
    */
    private void Patroling()
    {
        if (canMove)
        {
            if (!walkPointSet) SearchWalkPoint();

            if (walkPointSet)
                agent.SetDestination(walkPoint);

            Vector3 distanceToWalkPoint = transform.position - walkPoint;

            //Walkpoint reached
            if (distanceToWalkPoint.magnitude < 1f)
                walkPointSet = false;
        }
    }

    /**
    * SearchWalkPoint method for searching walkpoint
    * @return void
    */
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    /**
    * ChasePlayer method for chasing the player if conditions are met
    * @return void
    */
    private void ChasePlayer()
    {
        if (canMove)
        {
            agent.SetDestination(player.position);
            animator.SetBool("isWalking", true);
        }
    }

    /**
    * AttackPlayer method for attacking the player if conditions are met
    * @return void
    */
    private void AttackPlayer()
    {
        if (canMove)
        {
            //Make sure enemy doesn't move
            agent.SetDestination(transform.position);

            transform.LookAt(player);

            if (!alreadyAttacked)
            {
                ///Attack code here
                animator.SetBool("isWalking", false);
                animator.SetTrigger("attack");
                enemyAttacks.duringAttackAnimation = true;
                ///End of attack code

                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        }
    }

    /**
    * ResetAttack method for resetting whether the enemy can attack
    * @return void
    */
    private void ResetAttack()
    {
        alreadyAttacked = false;
        enemyAttacks.duringAttackAnimation = true;
    }

    /**
    * OnDrawGizmosSelected method for creating spheres for attackRange and sightRange
    * @return void
    */
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    // ------DAMAGE ENEMY-----

    /**
    * Enemy takes damage
    * @param damage The amount distating the amount of health loss
    */
    public void TakeDamage(GameObject enemy, float WeaponDamage)
    {
        if (enemy == gameObject)
        {
            if (enemyCanTakeDamage)
            {
                animator.SetTrigger("GettingHit");
                var totalDamage = playerStats.PlayerStrenght * WeaponDamage;
                EnemyHealth -= totalDamage;
                enemyCanTakeDamage = false;
                Invoke(nameof(ResetCanTakeDamage), 2);
            }
        }
    }

    /**
    * Enemy takes damage from magic
    * @param damage The amount distating the amount of health loss
    */
    public void TakeDamageFromMagic(float damage)
    {
        animator.SetTrigger("GettingHit");
        EnemyHealth -= damage;
    }

    /**
    * ResetCanTakeDamage method for resetting whether the enemy can take damage
    * @return void
    */
    private void ResetCanTakeDamage()
    {
        enemyCanTakeDamage = true;
    }

}
