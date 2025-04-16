using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ChallengeTrigger : MonoBehaviour {
    private int target = 5;

    public AudioSource audioSource;
    public AudioSource audioSource2;

    void OnTriggerEnter(Collider col){

        if(col.gameObject.tag == "Player"){
            if(GameManager.Instance.getCollected() < target){
                GameManager.Instance.AddToTimer();
                audioSource.Play();
                GameManager.Instance.incrementCollected();
                gameObject.SetActive(false);
            } else {
                audioSource2.Play();
                GameManager.Instance.exitChallenge();
                SceneManager.LoadScene(1);
            }
        }
        //     if (GameManager.Instance.getCollected() >= target){
        //         GameManager.Instance.exitChallenge();
        //         SceneManager.LoadScene(1);
        //     } else {
        //         GameManager.Instance.incrementCollected();
        //         Destroy(gameObject);
        //     }
        // }
    }
    
}
