using UnityEngine;

public class PlayerController1 : MonoBehaviour {
    public GameManager1 gameManager;

    void Update() {
        if (Input.GetKeyDown(KeyCode.W)) gameManager.Move("Backward");
        if (Input.GetKeyDown(KeyCode.S)) gameManager.Move("Forward");
        if (Input.GetKeyDown(KeyCode.A)) gameManager.Move("Right");
        if (Input.GetKeyDown(KeyCode.D)) gameManager.Move("Left");
    }
}
