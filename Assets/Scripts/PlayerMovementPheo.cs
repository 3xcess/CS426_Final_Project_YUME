using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PlayerMovementPheo : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public string nextSceneName;
    public float mouseSensitivity = 2f;

    private Rigidbody rb;
    private bool isGrounded = true;
    private bool invertMovement = false;
    private float rotationY = 0f;

    private static readonly HashSet<string> InvertScenes = new HashSet<string>
    {
        "Nightmare", "Challenge 1", "Challenge 2", "Challenge 3"
    };

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        string currentScene = SceneManager.GetActiveScene().name;

        if (InvertScenes.Contains(currentScene))
            invertMovement = true;
    }

    void Update()
    {
        RotatePlayer();
        HandleJump();

        if (Input.GetKeyDown(KeyCode.R) && InvertScenes.Contains(SceneManager.GetActiveScene().name))
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
            moveX = -moveX;
            moveZ = -moveZ;
        }

        Vector3 movement = (transform.forward * moveZ + transform.right * moveX).normalized * speed;
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z); // Use Rigidbody.velocity
    }

    void RotatePlayer()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationY += mouseX;

        // Optional: Clamp rotation if needed
        // rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
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
