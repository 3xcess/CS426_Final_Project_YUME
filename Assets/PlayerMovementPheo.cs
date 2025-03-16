using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementPheo : MonoBehaviour
{
    public float speed = 5f;
    public string nextSceneName; // Name of the scene to switch to

    private Rigidbody rb;
    private bool invertMovement = false; // Flag to determine inverted controls

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Check which scene is currently active
        if (SceneManager.GetActiveScene().name == "Nightmare") // Replace with actual scene name
        {
            invertMovement = true; // Enable inverted controls in Scene2
        }
    }

    void Update()
    {
        MovePlayer();

        if (Input.GetKeyDown(KeyCode.R))
        {
            SwitchScene();
        }
    }

    void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Invert controls if in Scene2
        if (invertMovement)
        {
            moveX = -moveX;
            moveZ = -moveZ;
        }

        Vector3 movement = new Vector3(moveX, 0, moveZ).normalized * speed ;
        rb.MovePosition(transform.position + movement);
            rb.AddForce(movement, ForceMode.Force); // Apply continuous force for smooth movement

    }

    void SwitchScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
