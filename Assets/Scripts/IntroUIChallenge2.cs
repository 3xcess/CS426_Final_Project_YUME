using UnityEngine;

public class IntroUIChallenge2 : MonoBehaviour
{
    public GameObject introPanel;        
    public GameObject backgroundImage;   

    private bool hasIntroBeenDismissed = false;

    void Start()
    {
        introPanel.SetActive(true);
        backgroundImage.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f; // Pause game
    }

    void Update()
    {
        // 
        if (hasIntroBeenDismissed && Input.GetKeyDown(KeyCode.H))
        {
            introPanel.SetActive(true);
            backgroundImage.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Time.timeScale = 0f; // Pause again
        }
    }

    public void OnStartClicked()
    {
        introPanel.SetActive(false);
        backgroundImage.SetActive(false);

        hasIntroBeenDismissed = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1f; // Resume game
    }
}
