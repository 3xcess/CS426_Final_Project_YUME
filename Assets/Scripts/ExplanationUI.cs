using UnityEngine;
using UnityEngine.UI;

public class ExplanationUI : MonoBehaviour
{
    public GameObject explanationPanel;
    public Button startButton;
    public Button helpButton;
    public GameObject backgroundImage; 

    void Start()
    {
        explanationPanel.SetActive(true); // Show at start
        if (backgroundImage != null) backgroundImage.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        startButton.onClick.AddListener(HideExplanation);
        helpButton.onClick.AddListener(ShowExplanation);
    }

    void HideExplanation()
    {
        explanationPanel.SetActive(false);
        if (backgroundImage != null) backgroundImage.SetActive(false);
    }

    void ShowExplanation()
    {
        explanationPanel.SetActive(true);
        if (backgroundImage != null) backgroundImage.SetActive(true);
    }
}
