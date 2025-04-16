using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
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
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Challenge 2")
        {
            SetEnemyVolume(0.1f);
        }
    }

    public void SetEnemyVolume(float targetVolume, float fadeSpeed = 2f)
    {
        if (enemyAudioSource == null) return;

        if (!enemyAudioSource.isPlaying)
            enemyAudioSource.Play();

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
