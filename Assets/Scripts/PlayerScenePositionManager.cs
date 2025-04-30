using UnityEngine;
using System.Collections;

public class PlayerScenePositionManager : MonoBehaviour
{
    public string playerID;

    void Start()
    {
        StartCoroutine(ApplySavedPositionNextFrame());
    }

    IEnumerator ApplySavedPositionNextFrame()
    {
        yield return null;

        if (GameManager.Instance != null &&
            GameManager.Instance.TryGetSavedPosition(playerID, out Vector3 savedPos))
        {
            Debug.Log($":white_check_mark: Position restored for {playerID}: {savedPos}");

            CharacterController cc = GetComponent<CharacterController>();
            if (cc != null)
            {
                cc.enabled = false; // :octagonal_sign: disable to allow manual move
            }

            transform.position = savedPos;

            if (cc != null)
            {
                cc.enabled = true; // :white_check_mark: re-enable
            }
        }
        else
        {
            Debug.Log($":x: No saved position for {playerID}");
        }
    }

    public void SavePosition()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.SavePlayerPosition(playerID, transform.position);
        }
    }
}