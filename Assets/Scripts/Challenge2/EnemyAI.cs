using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private Animator anim;
    private NavMeshAgent agent;
    public EnemyState currentState;
    public Transform[] patrolPoints;
    public Transform player;
    public float chaseRange = 10f;
    public float attackRange = 10f;
    public float fleeHealthThreshold = 20f;
    public float damage = 5f;
    public float attackCooldown = 1.5f;

    private int currentPatrolIndex;
    private float health = 100f;
    private bool isWaitingAtPoint = false;
    private bool isAttacking = false;
    private bool isDeadHandled = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        currentState = EnemyState.Patrol;
    }

    void Update()
    {
        HandleState();
        CheckTransitions();
    }

    void HandleState()
    {
        switch (currentState)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Patrol:
                Patrol();
                break;
            case EnemyState.Chase:
                Chase();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Dead:
                Dead();
                break;
        }

        SetAudioVolume();
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
        agent.speed = 2f;
        agent.destination = patrolPoints[currentPatrolIndex].position;
        anim.SetTrigger("Patrol");

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

    void Dead()
    {
        if (isDeadHandled) return;

        isDeadHandled = true;
        agent.isStopped = true;
        StopAllCoroutines();
        // anim.SetTrigger("Die"); // Optional
        Destroy(gameObject, 2f);
    }

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

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            currentState = EnemyState.Dead;
        }
    }

    void SetAudioVolume()
    {
        float volume = currentState switch
        {
            EnemyState.Idle => 0.1f,
            EnemyState.Patrol => 0.2f,
            EnemyState.Chase => 0.5f,
            EnemyState.Attack => 1.0f,
            _ => 0f
        };

        AudioManager.Instance.SetEnemyVolume(volume);
    }
}
