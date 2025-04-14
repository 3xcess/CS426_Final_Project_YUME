using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementPheo : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public string nextSceneName; // Name of the scene to switch to
    public float mouseSensitivity = 2f;

    private Rigidbody rb;
    private bool isGrounded = true;
    private bool invertMovement = false; // Flag to determine inverted controls
    private float rotationY = 0f;

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
        RotatePlayer(); // Handle mouse rotation
        HandleJump();

        if (Input.GetKeyDown(KeyCode.R) && !(SceneManager.GetActiveScene().name != "Challenge 1" || SceneManager.GetActiveScene().name != "Challenge 2" || SceneManager.GetActiveScene().name != "Challenge 3"))
        {
            SwitchScene();
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        if (invertMovement)
        {
            moveX = -moveX; // Invert horizontal movement
            moveZ = -moveZ; // Invert vertical movement
        }

        Vector3 movement = transform.forward * moveZ + transform.right * moveX;
        movement.Normalize();
        movement *= speed;

        if (rb.linearVelocity.y != 0)
        {
            rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
        }
    }

    void RotatePlayer()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationY += mouseX;
        transform.rotation = Quaternion.Euler(0, rotationY, 0); // Apply rotation to player
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void SwitchScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
