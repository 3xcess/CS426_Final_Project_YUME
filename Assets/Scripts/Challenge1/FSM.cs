using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    public enum EnemyState { Idle, Moving, attack, Dying }
    public EnemyState currentState = EnemyState.Idle;

    public float detectionRange = 10f;
    public float attackRange = 2f;
    public float attackDamage = 2f;
    public float attackCooldown = 3f;
    public float moveSpeed = 1f;

    protected float lastAttackTime = 0f;
    protected float distToPlayer;
    protected NavMeshAgent agent;
    protected Transform player;
    protected Animator animator;

    public GameObject ghost_normal;
    public GameObject ghost_Parts;

    protected virtual void Start()
    {
        ghost_normal.SetActive(true);
        ghost_Parts.SetActive(false);

        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        agent.speed = moveSpeed;
    }

    protected virtual void Update()
    {
        if (currentState == EnemyState.Dying) return;

        distToPlayer = Vector3.Distance(transform.position, player.position);

        if (distToPlayer <= attackRange){
            animator.SetTrigger("Attack");
            currentState = EnemyState.attack;
            TryAttack();
        }
        else if (distToPlayer <= detectionRange){
            animator.SetTrigger("Moving");
            currentState = EnemyState.Moving;
            MoveToPlayer();
        }
        else{
            currentState = EnemyState.Idle;
        }
    }

    protected virtual void MoveToPlayer(){
        if (agent != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            Vector3 destination = player.position - direction * 2f;
            agent.SetDestination(destination);
            currentState = EnemyState.Moving;
        }
    }

    protected virtual void TryAttack(){
        
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            GameManager.Instance.DamageHealth(attackDamage);
            lastAttackTime = Time.time;
        }
    }

    public virtual void Die()
    {
        if (currentState == EnemyState.Dying) return;
        
        currentState = EnemyState.Dying;
        ghost_Parts.SetActive(true);
        ghost_normal.SetActive(false);
        Destroy(gameObject, 3f);
    }
}
