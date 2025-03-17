using UnityEngine;
using static GameManager;

public class PuzzleWinCondition : MonoBehaviour
{
    public GameObject winText;

    void Start()
    {
        winText.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Box")
        {
            winText.SetActive(true);
            GameManager.Instance.AddToTimer();
            Destroy(other);
        }
    }

    void Update(){
        if (winText && Input.GetKeyDown(KeyCode.LeftShift)){
            winText.SetActive(false);
        }
    }
}
