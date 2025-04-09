using UnityEngine;
using UnityEngine.SceneManagement;

public class Treasure : MonoBehaviour {
    public UIWinManager winManager;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log("🎉 You found the treasure! YOU WIN!");

            // Disable or destroy the treasure
            gameObject.SetActive(false); // or use Destroy(gameObject)

            // Show win message
            if (winManager != null) {
                winManager.ShowWinMessage();
            }
            SceneManager.LoadScene("Nightmare");
        }
    }
}