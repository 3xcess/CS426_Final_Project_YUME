using UnityEngine;
using TMPro;

public class UIWinManager : MonoBehaviour {
    public TextMeshProUGUI winText;

    public void ShowWinMessage() {
        winText.gameObject.SetActive(true);
    }
}
