using UnityEngine;
using TMPro;

public class IntroUIController : MonoBehaviour
{
    public GameObject introPanel;
    public GameObject introHelpPanel;
    public GameObject gameplayHelpPanel;  
    public GameObject videoBackground;
    public GameObject storyPanel;
    public TextMeshProUGUI pressHText;

    private bool isStoryActive = false;
    private static bool storyShown = false;
    private bool isGameplayHelpActive = false;

    void Start()
    {
        introHelpPanel?.SetActive(false);
        gameplayHelpPanel?.SetActive(false);
        storyPanel?.SetActive(false);
        pressHText?.gameObject.SetActive(false);

        if (GameManager.Instance.hasIntroPlayed)
        {
            introPanel.SetActive(false);
            videoBackground.SetActive(false);
            GameManager.Instance.hasGameStarted = true;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            pressHText.gameObject.SetActive(true);
            return;
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameManager.Instance.hasGameStarted = false;
    }

    void Update()
    {
        
        if (isStoryActive && Input.GetKeyDown(KeyCode.Return))
        {
            CloseStory();
        }

        
        if (GameManager.Instance.hasGameStarted && !isStoryActive && Input.GetKeyDown(KeyCode.H))
        {
            isGameplayHelpActive = !isGameplayHelpActive;
            gameplayHelpPanel.SetActive(isGameplayHelpActive);
            Time.timeScale = isGameplayHelpActive ? 0f : 1f;

            Cursor.lockState = isGameplayHelpActive ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = isGameplayHelpActive;
        }

        
        if (isGameplayHelpActive && Input.GetKeyDown(KeyCode.Return))
        {
            gameplayHelpPanel.SetActive(false);
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isGameplayHelpActive = false;
        }
    }

    public void OnStartClicked()
    {
        introPanel.SetActive(false);
        introHelpPanel.SetActive(false);
        videoBackground.SetActive(false);

        if (!storyShown)
        {
            ShowStory();
        }
        else
        {
            StartGameplay();
        }
    }

    void ShowStory()
    {
        storyPanel.SetActive(true);
        isStoryActive = true;
        storyShown = true;

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void CloseStory()
    {
        storyPanel.SetActive(false);
        StartGameplay();
    }

    void StartGameplay()
    {
        GameManager.Instance.hasGameStarted = true;
        GameManager.Instance.hasIntroPlayed = true;

        Time.timeScale = 1f;
        isStoryActive = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        pressHText?.gameObject.SetActive(true);
    }

    public void OnHelpClicked()
    {
        introHelpPanel.SetActive(!introHelpPanel.activeSelf);
    }

    public void OnBackClicked()
    {
        introHelpPanel.SetActive(false);
        introPanel.SetActive(true);
    }
}