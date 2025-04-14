using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private Animator anim;
    public EnemyState currentState;
    public Transform[] patrolPoints;
    private int currentPatrolIndex;
    public Transform player;
    public float chaseRange = 10f;
    public float attackRange = 1f;
    public float fleeHealthThreshold = 20f;
    private NavMeshAgent agent;
    private float health = 100f;
    private bool isWaitingAtPoint = false;
    public float damage = 5f;
    public float attackCooldown = 1.5f;
    private bool isAttacking = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        currentState = EnemyState.Patrol;
    }

    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Idle:
                Idle();
                AudioManager.Instance.SetEnemyVolume(0.1f);
                break;
            case EnemyState.Patrol:
                Patrol();
                AudioManager.Instance.SetEnemyVolume(0.2f);
                break;
            case EnemyState.Chase:
                Chase();
                AudioManager.Instance.SetEnemyVolume(0.6f);
                break;
            case EnemyState.Attack:
                Attack();
                AudioManager.Instance.SetEnemyVolume(1.0f);
                break;
        }

        CheckTransitions();
    }
    

    void Idle()
    {
        anim.Play("Idle");
        agent.isStopped = true;
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0 || isWaitingAtPoint) return;

        agent.isStopped = false;
        agent.destination = patrolPoints[currentPatrolIndex].position;
        anim.SetTrigger("Patrol");
        agent.speed = 2f;

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            StartCoroutine(WaitAtPatrolPoint());
        }
    }

    IEnumerator WaitAtPatrolPoint()
    {
        isWaitingAtPoint = true;
        currentState = EnemyState.Idle;
        agent.isStopped = true;
        anim.SetTrigger("Idle");

        yield return new WaitForSeconds(3.5f);

        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        currentState = EnemyState.Patrol;
        agent.isStopped = false;
        isWaitingAtPoint = false;
    }

    void Chase()
    {
        agent.isStopped = false;
        agent.destination = player.position;
        anim.SetTrigger("Chase");
    }

    void Attack()
    {
        agent.isStopped = true;
        Vector3 playerPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(playerPosition);
        anim.SetTrigger("Attack");

        if (!isAttacking)
            StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        isAttacking = true;

        while (currentState == EnemyState.Attack)
        {
            GameManager.Instance.DamageHealth(damage);

            yield return new WaitForSeconds(attackCooldown);
        }

        isAttacking = false;
    }

    // void Flee()
    // {
    //     Vector3 dir = (transform.position - player.position).normalized;
    //     Vector3 fleePos = transform.position + dir * 10f;

    //     agent.isStopped = false;
    //     agent.destination = fleePos;
    //     // animator.Play("Run");
    // }

    // void Dead()
    // {
    //     agent.isStopped = true;
    //     // animator.Play("Die");
    //     // Disable further logic if needed
    //     this.enabled = false;
    // }

    void CheckTransitions()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (health <= 0)
        {
            currentState = EnemyState.Dead;
        }
        else if (health < fleeHealthThreshold)
        {
            currentState = EnemyState.Flee;
        }
        else if (distanceToPlayer <= attackRange)
        {
            currentState = EnemyState.Attack;
        }
        else if (distanceToPlayer <= chaseRange)
        {
            currentState = EnemyState.Chase;
        }
        else
        {
            currentState = EnemyState.Patrol;
        }
    }

    // Call this when taking damage
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
