using UnityEngine;
using TMPro;

public class NightmareHelpUI : MonoBehaviour
{
    [Header("UI References")]
    public GameObject helpPanel;             // Your Instructions panel
    public TextMeshProUGUI instructionHint;  // "Press H for instructions" text

    private bool isHelpOpen = false;

    void Start()
    {
        helpPanel.SetActive(false);           // Hide panel at start
        if (instructionHint != null)
            instructionHint.gameObject.SetActive(true); // Always show "Press H for Instructions"
        
        Time.timeScale = 1f;                  // Ensure game runs normally at start
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && !isHelpOpen)
        {
            OpenHelp();
        }
        else if (Input.GetKeyDown(KeyCode.Return) && isHelpOpen) // Return = Enter Key
        {
            CloseHelp();
        }
    }

    void OpenHelp()
    {
        helpPanel.SetActive(true);
        Time.timeScale = 0f; // Pause game
        isHelpOpen = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void CloseHelp()
    {
        helpPanel.SetActive(false);
        Time.timeScale = 1f; // Resume game
        isHelpOpen = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}