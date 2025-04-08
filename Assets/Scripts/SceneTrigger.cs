using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider other){
        GameManager.Instance.enterChallenge();
        SceneManager.LoadScene(2);
    }
    
}
