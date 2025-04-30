using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTeleport : MonoBehaviour
{
    [Tooltip("Name of the scene to teleport to")]
    public string targetScene = "Dreams";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Teleporting to: " + targetScene);
            SceneManager.LoadScene(targetScene);
        }
    }
}