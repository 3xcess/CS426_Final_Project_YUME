using UnityEngine;
using UnityEngine.AI;

public class HiddenEnemyAI : EnemyBase{
    public float moveSpeedHidden = 0.5f;
    public float moveSpeedRevealed = 1f;
    public float hiddenAttackDamage = 1f;
    public float revealedAttackDamage = 3f;
    public float hiddenAttackCooldown = 2f;
    public float revealedAttackCooldown = 3f;

    public Material hostileMaterial;
    public Material friendlyMaterial;

    private BayesianDecisionMaker decisionMaker;
    
    
    private bool othersAttacking;
    
    private bool playerNear;

    protected override void Start(){
        base.Start();

        decisionMaker = new BayesianDecisionMaker();
        agent.speed = moveSpeedHidden;
        attackDamage = hiddenAttackDamage;
        attackCooldown = hiddenAttackCooldown;
    }

    protected override void Update(){   
        playerNear = distToPlayer < attackRange;
        othersAttacking = WaveManager.Instance.OtherEnemiesAttacking();
        base.Update();
    }

    protected override void TryAttack() { 
        playerNear = distToPlayer < detectionRange;
        othersAttacking = WaveManager.Instance.OtherEnemiesAttacking();

        if (decisionMaker.ShouldAttack(playerNear, false, othersAttacking)){
            base.TryAttack();
        } else if (decisionMaker.ShouldReveal(playerNear, false, othersAttacking)){
            base.MoveToPlayer();
        } else {
        }
    }

    public override void Die(){
        if (currentState == EnemyState.Dying) return;
        currentState = EnemyState.Dying;
        ghost_Parts.SetActive(true);
        ghost_normal.SetActive(false);

        Destroy(gameObject, 3f);
    }
}