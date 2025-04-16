using UnityEngine;

public class TreasureTrigger : MonoBehaviour
{
    private Animator anim;

    [Header("Player Settings")]
    public Transform player; 
    public float triggerDistance = 2.5f;

    [Header("Sound Settings")]
    public AudioSource audioSource; 
    public AudioClip fallSound;     

    private bool hasFallen = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (hasFallen) return;

       
        if (Vector3.Distance(transform.position, player.position) <= triggerDistance)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (anim != null)
                {
                    anim.SetTrigger("FallBackTrigger");
                    Debug.Log("Treasure animation triggered!");

                    
                    if (audioSource != null)
                    {
                        if (fallSound != null)
                            audioSource.PlayOneShot(fallSound);
                        else
                            audioSource.Play(); 
                    }

                    hasFallen = true; 
                }
            }
        }
    }
}