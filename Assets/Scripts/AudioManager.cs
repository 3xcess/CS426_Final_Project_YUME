using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource enemyAudioSource;
    public AudioSource sfxSource;
    private Coroutine volumeFadeCoroutine;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void SetEnemyVolume(float targetVolume, float fadeSpeed = 2f)
    {
        if (enemyAudioSource == null) return;

        if (SceneManager.GetActiveScene().name == "Challenge 2")
        {
            if (!enemyAudioSource.isPlaying)
            {
                enemyAudioSource.Play();
            }
        }
        else
        {
            return; // Exit early if not in Challenge 2
        }

        // Fade volume
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

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}
