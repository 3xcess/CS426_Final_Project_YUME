using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScenePositionManager : MonoBehaviour
{
    public string playerID;
    
    void Start(){
        if (GameManager.Instance.TryGetSavedPosition(playerID, out Vector3 savedPos))
        {
            transform.position = savedPos;
        }
    }

    public void SavePosition(){
        GameManager.Instance.SavePlayerPosition(playerID, transform.position);
    }
}
