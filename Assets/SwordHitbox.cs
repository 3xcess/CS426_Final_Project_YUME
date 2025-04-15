using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    public float damage = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // Make sure your enemy has the "Enemy" tag
        {
            EnemyAI enemy = other.GetComponent<EnemyAI>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
