using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PlayerScenePositionManager : MonoBehaviour
{
    [SerializeField] private string playerID = "PlayerA";

    private static Dictionary<string, Vector3> sessionPositions = new();

    private string GetKey()
    {
        return $"{SceneManager.GetActiveScene().name}_{playerID}";
    }

    void Start()
    {
        string key = GetKey();
        if (sessionPositions.ContainsKey(key))
        {
            transform.position = sessionPositions[key];
        }
    }

    public void SavePosition()
    {
        sessionPositions[GetKey()] = transform.position;
    }

    public void ClearSavedPosition()
    {
        sessionPositions.Remove(GetKey());
    }
}
