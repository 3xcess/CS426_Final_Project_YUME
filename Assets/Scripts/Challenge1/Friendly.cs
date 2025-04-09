using UnityEngine;
using UnityEngine.AI;

public class FriendlyEnemy : EnemyBase
{
    protected override void Start()
    {
        base.Start();
        moveSpeed = 1f;
        attackRange = 0f;
        attackDamage = 0f;
    }

    protected override void TryAttack() { }

    public override void Die()
    {
        if (currentState == EnemyState.Dying) return;
        currentState = EnemyState.Dying;
        ghost_Parts.SetActive(true);
        ghost_normal.SetActive(false);
        Destroy(gameObject, 2f);
    }

    public void KillOnWaveClear()
    {
        if (currentState != EnemyState.Dying)
        {
            Die();
        }
    }
}