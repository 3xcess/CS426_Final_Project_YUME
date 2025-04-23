using UnityEngine;

public class AmbientSound : MonoBehaviour
{
    public AudioSource audioSource;

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            audioSource.Play();
        }
    }
}
