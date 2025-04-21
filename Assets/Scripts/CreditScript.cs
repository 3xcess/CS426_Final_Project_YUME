using UnityEngine;

public class CreditScript : MonoBehaviour
{
    private RectTransform creditsTransform;
    public float scrollSpeed = 50f;
    public float endY = 1000f;

    public CanvasGroup fadeInGroup;
    public float fadeSpeed = 1f;

    private bool isScrolling = false;
    private bool startFade = false;

    void Start()
    {
        creditsTransform = GetComponent<RectTransform>();
        fadeInGroup.alpha = 0f; // Ensure it's hidden on start
    }

    void Update()
    {
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
                startFade = true;
            }
        }

        if (startFade)
        {
            fadeInGroup.alpha = Mathf.MoveTowards(fadeInGroup.alpha, 1f, fadeSpeed * Time.unscaledDeltaTime);

            // Optional: Once fade is complete, move to another scene
            if (fadeInGroup.alpha >= 1f)
            {
                // SceneManager.LoadScene("MainMenu");
            }
        }
    }

    // Call this to trigger the credits
    public void StartCredits()
    {
        isScrolling = true;
    }
}
