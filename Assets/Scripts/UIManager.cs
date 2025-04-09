using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {
    public TextMeshProUGUI wrongMoveText;
    public float displayDuration = 2f;

    public void ShowWrongMoveMessage() {
        wrongMoveText.gameObject.SetActive(true);
        CancelInvoke(nameof(HideText)); // reset if already invoked
        Invoke(nameof(HideText), displayDuration);
    }

    void HideText() {
        wrongMoveText.gameObject.SetActive(false);
    }
}
