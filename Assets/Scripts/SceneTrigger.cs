using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    [SerializeField] int sceneToLoad;

    void OnTriggerEnter(Collider other)
{
    if (GameManager.Instance == null)
    {
        Debug.LogError("GameManager is not set in the scene!");
        return;
    }

    GameManager.Instance.enterChallenge();
    SceneManager.LoadScene(sceneToLoad);
}
}
