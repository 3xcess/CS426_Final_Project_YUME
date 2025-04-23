using UnityEngine;

public class EnemyHitFlash : MonoBehaviour
{
    public Renderer enemyRenderer;
    public float flashDuration = 0.2f;

    private Material _matInstance;
    private float _flashTimer;

    void Start()
    {
        if (enemyRenderer == null)
            enemyRenderer = GetComponentInChildren<Renderer>();

        // Instantiate material to avoid changing shared material
        _matInstance = enemyRenderer.material;
        _matInstance.SetFloat("_HitEffectIntensity", 0f);
    }

    void Update()
    {
        if (_flashTimer > 0)
        {
            _flashTimer -= Time.deltaTime;
            float t = Mathf.Clamp01(_flashTimer / flashDuration);
            _matInstance.SetFloat("_HitEffectIntensity", t);
        }
    }

    public void FlashRed()
    {
        _flashTimer = flashDuration;
        _matInstance.SetFloat("_HitEffectIntensity", 1f);
    }
}
