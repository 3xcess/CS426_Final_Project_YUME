using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public float mouseSensitivity = 2f; // Controls mouse look sensitivity
    public string nextSceneName = "Nightmare";

    private Rigidbody rb;
    private bool isGrounded = true; 

    private float rotationY = 0f; // Store player rotation

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to center of screen
    }

    void Update()
    {
        RotatePlayer(); // Handle mouse rotation
        HandleJump(); 

        if (Input.GetKeyDown(KeyCode.R)) 
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
  

        Vector3 movement = transform.forward * moveZ + transform.right * moveX;
        movement.Normalize();
        movement *= speed;

        if (isGrounded || rb.linearVelocity.y != 0) 
        {
            rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
        }
    }

    void RotatePlayer()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity; // Get mouse horizontal movement
        rotationY += mouseX; // Accumulate rotation
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