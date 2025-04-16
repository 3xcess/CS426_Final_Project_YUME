using UnityEngine;

public class IntroUIController : MonoBehaviour
{
    public GameObject introPanel;
    public GameObject helpPanel;
    public GameObject videoBackground;

void Start()
{
    if (GameManager.Instance.hasIntroPlayed)
    {
        // Skip intro if already played
        introPanel.SetActive(false);
        helpPanel.SetActive(false);
        videoBackground.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        GameManager.Instance.hasGameStarted = true;
        return;
    }

    // First time — show intro
    helpPanel.SetActive(false);
   // videoPlayer.Play();

    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;

    GameManager.Instance.hasGameStarted = false;
}

    public void OnStartClicked()
    {
        introPanel.SetActive(false);
        helpPanel.SetActive(false);
        GameManager.Instance.hasGameStarted = true;
        GameManager.Instance.hasIntroPlayed = true;

        if (videoBackground != null)
            videoBackground.SetActive(false); 
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnHelpClicked()
    {
        helpPanel.SetActive(!helpPanel.activeSelf);
    }
    public void OnBackClicked()
    {
        helpPanel.SetActive(false);
        introPanel.SetActive(true);
    }
}