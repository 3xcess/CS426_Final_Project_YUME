using UnityEngine;
using TMPro;

public class StoryAndHelpManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject storyCanvas;
    public GameObject helpPanel;
    public TextMeshProUGUI pressHText;

    private static bool storyShownOnce = false;
    private bool isStoryActive = false;
    private bool isHelpActive = false;

    void Start()
    {
        // Show story only the first time the scene is entered
        if (!storyShownOnce)
        {
            ShowStory();
        }
        else
        {
            pressHText?.gameObject.SetActive(true);
        }

        helpPanel?.SetActive(false);
    }

    void Update()
    {
        if (isStoryActive && Input.GetKeyDown(KeyCode.Return))
        {
            CloseStory();
        }
        else if (!isStoryActive && Input.GetKeyDown(KeyCode.H))
        {
            ToggleHelp();
        }
        else if (isHelpActive && Input.GetKeyDown(KeyCode.Return))
        {
            CloseHelp();
        }
    }

    void ShowStory()
    {
        storyCanvas.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isStoryActive = true;
        storyShownOnce = true;
        pressHText?.gameObject.SetActive(false);
    }

    void CloseStory()
    {
        storyCanvas.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isStoryActive = false;
        pressHText?.gameObject.SetActive(true);
    }

    void ToggleHelp()
    {
        if (!isHelpActive)
        {
            helpPanel.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isHelpActive = true;
        }
    }

    void CloseHelp()
    {
        helpPanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isHelpActive = false;
    }
}