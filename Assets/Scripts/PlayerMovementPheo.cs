using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementPheo : MonoBehaviour
{
    public float speed = 0.3f;
    public string nextSceneName; // Name of the scene to switch to
    public float mouseSensitivity = 2f;

    private Rigidbody rb;
    private bool invertMovement = false; // Flag to determine inverted controls
    private float rotationY = 0f;
    private float rotationX = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Check which scene is currently active
        if (SceneManager.GetActiveScene().name == "Nightmare" || SceneManager.GetActiveScene().name == "Challenge 1" || SceneManager.GetActiveScene().name == "Challenge 2" || SceneManager.GetActiveScene().name == "Challenge 3")
        {
            invertMovement = true; // Enable inverted controls in Scene2
        }
    }

    void Update()
    {
        MovePlayer();
        RotatePlayer();

        if (Input.GetKeyDown(KeyCode.R) && (SceneManager.GetActiveScene().name != "Challenge 1" || SceneManager.GetActiveScene().name != "Challenge 2" || SceneManager.GetActiveScene().name != "Challenge 3"))
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
    }

    void RotatePlayer()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationY += mouseX;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotationX -= mouseY;
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0); // Apply rotation to player
    }

    void SwitchScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
