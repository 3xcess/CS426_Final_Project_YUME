using UnityEngine;
using UnityEngine.AI;

public class HostileEnemy : EnemyBase
{
    protected override void Start()
    {
        base.Start();
        moveSpeed = 1.5f;
        attackDamage = 2f;
        attackCooldown = 3f;
    }
}