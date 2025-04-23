using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;

    [Header("Camera Settings")]
    public float mouseSensitivity = 2f;

    [Header("Scene Settings")]
    public string nextSceneName = "Nightmare";

    private CharacterController controller;
    private Animator anim;
    private Vector3 velocity;
    private float rotationY = 0f;

    private static readonly int SpeedHash = Animator.StringToHash("Speed");
    private static readonly int JumpHash = Animator.StringToHash("Jump");
    private static readonly int AttackHash = Animator.StringToHash("Attack");
    private static readonly int BackwardHash = Animator.StringToHash("Backward");

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        RotatePlayer();
        HandleMovement();

        if (Input.GetKeyDown(KeyCode.R) && SceneManager.GetActiveScene().name == "Dreams")
        {
            PlayerScenePositionManager currentPlayer = FindObjectOfType<PlayerScenePositionManager>();
            if (currentPlayer != null){
                currentPlayer.SavePosition();
            }
            SceneManager.LoadScene(nextSceneName);
        }
    }

    void HandleMovement()
    {
        bool isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Cache input
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        bool isJumpPressed = Input.GetButtonDown("Jump");
        bool isAttackPressed = Input.GetButtonDown("Fire1");

        // Horizontal movement
        Vector3 move = transform.right * inputX + transform.forward * inputZ;
        controller.Move(move * speed * Time.deltaTime);

        // Apply jump if grounded
        if (isJumpPressed && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            anim.SetTrigger(JumpHash);
        }

        // Apply gravity and move vertically
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Animation
        float moveSpeed = new Vector2(inputX, inputZ).magnitude;
        anim.SetFloat(SpeedHash, moveSpeed);
        anim.SetBool(BackwardHash, inputZ < 0);

        if (isAttackPressed)
        {
            anim.SetTrigger(AttackHash);
        }
    }

    void RotatePlayer()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationY += mouseX;
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
    }
}
