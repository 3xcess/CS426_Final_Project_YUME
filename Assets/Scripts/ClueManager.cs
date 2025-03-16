using UnityEngine;
using TMPro;

public class ClueManager : MonoBehaviour
{
  public static ClueManager Instance;

  public TMP_Text clueText;
  private bool isShowingClue = false;

  private void Awake()
  {
    if (Instance == null)
      Instance = this;
    else
      Destroy(gameObject);

    clueText.gameObject.SetActive(false);
  }

  public void ShowClue(ClueSphere.ClueType clueType)
  {
    string message = "";

    switch (clueType)
    {
      case ClueSphere.ClueType.Dialog:
        message = "You found a clue: Dialog";
        break;
      case ClueSphere.ClueType.Endgame:
        message = "You found a clue: Endgame";
        break;
      case ClueSphere.ClueType.PheoHints:
        message = "You found a clue: PheoHints";
        break;
    }

    clueText.text = message;
    clueText.gameObject.SetActive(true);
    isShowingClue = true;
  }

  private void Update()
  {
    if (isShowingClue && Input.GetKeyDown(KeyCode.LeftShift))
    {
      clueText.gameObject.SetActive(false);
      isShowingClue = false;
    }
  }
}
