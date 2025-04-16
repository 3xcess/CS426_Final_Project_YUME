using UnityEngine;

public class ClueSphere : MonoBehaviour
{
    public enum ClueType { Dialog, Endgame, PheoHints, Health }
    public ClueType clueType;

    [Header("Audio")]
    public AudioClip chimeClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySFX(chimeClip);
            // Get the clue manager and show the appropriate clue
            ClueManager.Instance.ShowClue(clueType);
            Destroy(gameObject); // Remove the sphere after collision
        }
    }
}
