using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ChallengeTrigger : MonoBehaviour {
    private int target = 1;

    void OnTriggerEnter(Collider col){
        if(col = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>()){
            if (GameManager.Instance.getCollected() >= target){
                GameManager.Instance.exitChallenge();
                SceneManager.LoadScene(1);
            } else {
                GameManager.Instance.incrementCollected();
                Destroy(gameObject);
            }
        }
    }
    
}
