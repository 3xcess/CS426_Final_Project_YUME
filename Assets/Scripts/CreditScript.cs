using UnityEngine;
using UnityEngine.UI;

public class CreditScript : MonoBehaviour
{
    private RectTransform creditsTransform;
    public float scrollSpeed = 50f;
    public float endY = 1000f;

    [Header("UI References")]
    public GameObject creditsPanel;

    private bool isScrolling = false;

    void Start()
    {
        creditsTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // ✅ Move key check here
        if (Input.GetKeyDown(KeyCode.C))
        {
            creditsPanel.SetActive(true);
            StartCredits();
        }

        if (isScrolling)
        {
            creditsTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.unscaledDeltaTime);

            if (creditsTransform.anchoredPosition.y >= endY)
            {
                creditsTransform.anchoredPosition = new Vector2(
                    creditsTransform.anchoredPosition.x,
                    endY
                );
                isScrolling = false;
            }
        }
    }

    public void StartCredits()
    {
        isScrolling = true;
    }
}
