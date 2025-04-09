using UnityEngine;
using UnityEngine.UI;

public class ExplanationUI : MonoBehaviour
{
    public GameObject explanationPanel;
    public Button startButton;
    public Button helpButton;

    void Start()
    {
        explanationPanel.SetActive(true); // Show at start
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        startButton.onClick.AddListener(HideExplanation);
        helpButton.onClick.AddListener(ShowExplanation);
    }

    void HideExplanation()
    {
        explanationPanel.SetActive(false);
    }

    void ShowExplanation()
    {
        explanationPanel.SetActive(true);
    }
}
