using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    
    public string sceneToLoad = "EndScene"; // 👈 your target scene
    private ClueSphere.ClueType clueType = ClueSphere.ClueType.Finale;

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            if(GameManager.Instance.finalTreasuresCollected()){
                Debug.Log("Player entered trigger — loading scene: " + sceneToLoad);
                SceneManager.LoadScene(sceneToLoad);
            } else {
                ClueManager.Instance.ShowClue(clueType, "What?!\nI'm still missing the ancient treasures needed to close this portal?! \n\nMaybe I need to find what I am missing quick...\nWho knows how much longer Pheo can hold out...");
            }
        }
    }
}