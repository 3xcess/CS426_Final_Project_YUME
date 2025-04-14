using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource enemyAudioSource;

    private Coroutine volumeFadeCoroutine;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SetEnemyVolume(float targetVolume, float fadeSpeed = 2f)
    {
        if (enemyAudioSource == null) return;

        // Stop any existing fade before starting a new one
        if (volumeFadeCoroutine != null)
            StopCoroutine(volumeFadeCoroutine);

        volumeFadeCoroutine = StartCoroutine(FadeVolume(targetVolume, fadeSpeed));
    }

    private IEnumerator FadeVolume(float targetVolume, float speed)
    {
        float startVolume = enemyAudioSource.volume;

        while (!Mathf.Approximately(enemyAudioSource.volume, targetVolume))
        {
            enemyAudioSource.volume = Mathf.MoveTowards(enemyAudioSource.volume, targetVolume, Time.deltaTime * speed);
            yield return null;
        }
    }
}
