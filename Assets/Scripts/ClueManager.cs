using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ClueManager : MonoBehaviour
{
  public static ClueManager Instance;
  public Image img;

  public TMP_Text clueText;
  private bool isShowingClue = false;

  private void Awake()
  {
    if (Instance == null)
      Instance = this;
    else
      Destroy(gameObject);

    clueText.gameObject.SetActive(false);
    img.gameObject.SetActive(false);
  }

  public void ShowClue(ClueSphere.ClueType clueType, string msg)
  {
    string message = "";

    switch (clueType)
    {
      case ClueSphere.ClueType.Dialog:
        message = msg;
        break;
      case ClueSphere.ClueType.Endgame:
        message = msg;
        GameManager.Instance.treasureFound();
        break;
      case ClueSphere.ClueType.PheoHints:
        message = msg;
        break;
      case ClueSphere.ClueType.Health:
        if(GameManager.Instance.getHealth() < 100){
          message = msg;
          GameManager.Instance.AddToHealth();
        } else {
          message = "Pheo already has max HP";
        }
        break;
      case ClueSphere.ClueType.Finale:
        message = msg; 
        break;
    }

    clueText.text = message;
    clueText.gameObject.SetActive(true);
    img.gameObject.SetActive(true);
    isShowingClue = true;
  }

  private void Update()
  {
    if (isShowingClue && Input.GetKeyDown(KeyCode.LeftShift))
    {
      clueText.gameObject.SetActive(false);
      img.gameObject.SetActive(false);
      isShowingClue = false;
    }
  }
}
