using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NightmareStoryManager : MonoBehaviour
{
    [Header("References")]
    public GameObject storyCanvas;
    public TextMeshProUGUI pressHText; 

    private bool storyActive = false;
    private static bool storyAlreadyShown = false;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Nightmare" && !storyAlreadyShown)
        {
            ShowStory();
        }
        else
        {
            
            if (pressHText != null)
                pressHText.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (storyActive && Input.GetButtonDown("Fire1")) // Press Enter
        {
            CloseStory();
        }
    }

    void ShowStory()
    {
        if (storyCanvas != null)
        {
            storyCanvas.SetActive(true);
            Time.timeScale = 0f; // Pause the game
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            storyActive = true;
            storyAlreadyShown = true;

            if (pressHText != null)
                pressHText.gameObject.SetActive(false); 
        }
    }

    void CloseStory()
    {
        if (storyCanvas != null)
        {
            storyCanvas.SetActive(false);
            Time.timeScale = 1f; // Resume the game
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            storyActive = false;

            if (pressHText != null)
                pressHText.gameObject.SetActive(true); 
        }
    }
}