using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementPheo : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public string nextSceneName;
    public float mouseSensitivity = 2f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Animator anim;
    private bool isGrounded = true;
    private bool invertMovement = false;
    private float rotationY = 0f;
    private Vector3 velocity;

    private static readonly HashSet<string> InvertScenes = new HashSet<string>
    {
        "Nightmare", "Challenge 1", "Challenge 2", "Challenge 3"
    };

    // Animator parameter hashes for better performance
    private static readonly int SpeedHash = Animator.StringToHash("Speed");
    private static readonly int JumpHash = Animator.StringToHash("Jump");
    private static readonly int AttackHash = Animator.StringToHash("Attack");
    private static readonly int BackwardHash = Animator.StringToHash("Backward");

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;

        string currentScene = SceneManager.GetActiveScene().name;
        if (InvertScenes.Contains(currentScene))
            invertMovement = true;
    }

    void Update()
    {
        RotatePlayer();
        HandleMovement();
        HandleJump();

        if (Input.GetKeyDown(KeyCode.R) && SceneManager.GetActiveScene().name== "Nightmare")
        {
            SwitchScene();
        }
    }

    void HandleMovement()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        bool isAttackPressed = Input.GetButtonDown("Fire1");

        if (invertMovement)
        {
            moveX = -moveX;
            moveZ = -moveZ;
        }

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Animator controls
        float movementSpeed = new Vector2(moveX, moveZ).magnitude;
        anim.SetFloat(SpeedHash, movementSpeed);
        anim.SetBool(BackwardHash, moveZ < 0);

        if (isAttackPressed)
        {
            anim.SetTrigger(AttackHash);

        }
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            anim.SetTrigger(JumpHash);
        }
    }

    void RotatePlayer()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationY += mouseX;
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
    }

    void SwitchScene()
    {
        SceneManager.LoadScene("Dreams");
    }
}
