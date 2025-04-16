using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
    public Image EnemyHealthBar;

    [Header("Health Settings")]
    public float maxHealth = 100f;
    public float currentHealth;

    public delegate void OnDeath();
    public event OnDeath onDeath;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        EnemyHealthBar.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0f)
        {
            currentHealth = 0f;
            onDeath?.Invoke();
        }
    }

    public bool IsDead()
    {
        return currentHealth <= 0f;
    }
}
