using UnityEngine;
using UnityEngine.SceneManagement;

public class Minigame : MonoBehaviour {
    public string mainSceneName = "Minigame"; 

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log("Teleporting back to main scene...");
            SceneManager.LoadScene(mainSceneName);
        }
    }
}