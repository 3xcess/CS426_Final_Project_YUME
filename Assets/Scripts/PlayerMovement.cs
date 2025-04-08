using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.3f;
    public string nextSceneName; // Name of the scene to switch to

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get Rigidbody component
    }

    void Update()
    {
        MovePlayer(); // Call movement function

        if (Input.GetKeyDown(KeyCode.R)) // If 'R' is pressed, switch scenes
        {
            SwitchScene();
        }
    }

    void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal"); // Get left/right movement
        float moveZ = Input.GetAxis("Vertical");   // Get forward/backward movement

        Vector3 movement = new Vector3(moveX, 0, moveZ).normalized * speed ;
        rb.MovePosition(transform.position + movement);
    }

    void SwitchScene()
    {
        SceneManager.LoadScene("Nightmare"); // Load the specified scene
    }
}
