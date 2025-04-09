using UnityEngine;

public class TreasureTrigger : MonoBehaviour
{
    private Animator anim;

    [Header("Player Settings")]
    public Transform player; // Drag your Player here in the Inspector
    public float triggerDistance = 2.5f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Check distance between player and treasure
        if (Vector3.Distance(transform.position, player.position) <= triggerDistance)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (anim != null)
                {
                    anim.SetTrigger("FallBackTrigger");
                    Debug.Log("Treasure animation triggered!");
                }
            }
        }
    }
}