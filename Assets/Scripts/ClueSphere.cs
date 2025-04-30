using UnityEngine;

public class ClueSphere : MonoBehaviour
{
    public enum ClueType { Dialog, Endgame, PheoHints, Health, Finale }
    public ClueType clueType;
    public string msg;

    [Header("Audio")]
    public AudioClip chimeClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySFX(chimeClip);
            // Get the clue manager and show the appropriate clue
            ClueManager.Instance.ShowClue(clueType, msg);
            Destroy(gameObject); // Remove the sphere after collision
        }
    }
}
