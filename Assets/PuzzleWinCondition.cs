using UnityEngine;

public class PuzzleWinCondition : MonoBehaviour
{
    public GameObject winText; // Reference to UI text

    void Start()
    {
        winText.SetActive(false); // Hide win message at the start
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Box") // Box reaches the target
        {
            winText.SetActive(true); // Display Win Message
            Debug.Log("Puzzle Solved! You Win!");
        }
    }
}
