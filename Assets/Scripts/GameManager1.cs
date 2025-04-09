using UnityEngine;
using System.Collections.Generic;
using System.Collections;  

public class GameManager1 : MonoBehaviour {
    public Transform player;
    public float moveDistance = 3f;
    private Vector3 spawnPoint;
    private List<string> lastTwoMoves = new List<string>();
    public UIManager uiManager;
    public GameObject explosionPrefab;
    private HashSet<Vector3> validPositions = new HashSet<Vector3>();

    private string[] directions = { "Forward", "Backward", "Left", "Right" };
    private Vector3 RoundToGrid(Vector3 pos) {
    float gridSize = moveDistance; // usually 3f
    return new Vector3(
        Mathf.Round(pos.x / gridSize) * gridSize,
        0f, // 👈 Important for accurate tile matching
        Mathf.Round(pos.z / gridSize) * gridSize
    );
}


private Dictionary<(string, string), int[]> predictionTable = new Dictionary<(string, string), int[]> {
    { ("Forward", "Forward"),   new int[] {10, 3, 2, 1} },  // Forward, Backward, Left, Right
    { ("Forward", "Backward"), new int[] {4, 8, 2, 1} },
    { ("Forward", "Left"),     new int[] {3, 1, 9, 4} },
    { ("Forward", "Right"),    new int[] {6, 2, 1, 7} },

    { ("Backward", "Forward"), new int[] {2, 10, 3, 1} },
    { ("Backward", "Backward"),new int[] {1, 9, 2, 5} },
    { ("Backward", "Left"),    new int[] {4, 3, 8, 2} },
    { ("Backward", "Right"),   new int[] {2, 5, 1, 9} },

    { ("Left", "Forward"),     new int[] {3, 2, 10, 1} },
    { ("Left", "Backward"),    new int[] {2, 4, 8, 2} },
    { ("Left", "Left"),        new int[] {1, 1, 9, 4} },
    { ("Left", "Right"),       new int[] {2, 2, 3, 9} },

    { ("Right", "Forward"),    new int[] {5, 1, 2, 10} },
    { ("Right", "Backward"),   new int[] {1, 3, 4, 8} },
    { ("Right", "Left"),       new int[] {3, 2, 5, 9} },
    { ("Right", "Right"),      new int[] {1, 1, 2, 10} }
};

void Start() {
    spawnPoint = player.position;

    GameObject[] floorTiles = GameObject.FindGameObjectsWithTag("Floor");
    foreach (GameObject tile in floorTiles) {
        Vector3 rounded = RoundToGrid(tile.transform.position);
        validPositions.Add(rounded);
}
}
 public void Move(string direction) {
    // Vector3 dir = DirectionToVector(direction);
    
    // Vector3 intendedMove = player.position + dir * moveDistance;
    // Vector3 testPosition = RoundToGrid(intendedMove); // for comparison
    // Vector3 nextPosition = new Vector3(testPosition.x, 1.5f, testPosition.z); // for actual movement

    // if (!validPositions.Contains(testPosition)) {
    //     Debug.Log("❌ Can't move there — no tile at " + testPosition);
    //     return;
    // }
     Vector3 dir = DirectionToVector(direction);

    // 🧠 Step 1: Round current position to nearest tile center
    Vector3 currentTile = RoundToGrid(player.position);

    // 🧠 Step 2: Calculate next tile center from current tile
    Vector3 nextTile = currentTile + dir * moveDistance;

    // 🧠 Step 3: Separate test position (for comparison)
    Vector3 testPosition = new Vector3(nextTile.x, 0f, nextTile.z); // for lookup
    Vector3 nextPosition = new Vector3(nextTile.x, 1.5f, nextTile.z); // final move position with Y

    if (!validPositions.Contains(testPosition)) {
        Debug.Log("❌ Can't move there — no tile at " + testPosition);
        return;
    }

    // Trap prediction logic...
    if (lastTwoMoves.Count == 2) {
        if (IsMovePredicted(direction)) {
            if (explosionPrefab != null)
                Instantiate(explosionPrefab, player.position, Quaternion.identity);

            if (uiManager != null)
                uiManager.ShowWrongMoveMessage();

            StartCoroutine(DelayedRespawn());
            lastTwoMoves.Clear();
            return;
        }
        lastTwoMoves.RemoveAt(0);
    }

    player.position = nextPosition;
    lastTwoMoves.Add(direction);
}

    private IEnumerator DelayedRespawn() {
    yield return new WaitForSeconds(0.5f); // Wait to let explosion play
    player.position = spawnPoint;
    }

    private bool IsMovePredicted(string thirdMove) {
        var key = (lastTwoMoves[0], lastTwoMoves[1]);
        if (!predictionTable.ContainsKey(key)) return false;

        int[] counts = predictionTable[key];
        int maxIndex = System.Array.IndexOf(counts, Mathf.Max(counts));
        string predictedMove = directions[maxIndex];

        Debug.Log($"Predicted: {predictedMove}, Actual: {thirdMove}");
        return predictedMove == thirdMove;
    }

    private Vector3 DirectionToVector(string dir) {
        return dir switch {
            "Forward" => new Vector3(0, 0, 1),
            "Backward" => new Vector3(0, 0, -1),
            "Left" => new Vector3(-1, 0, 0),
            "Right" => new Vector3(1, 0, 0),
            _ => Vector3.zero
        };
    }
}
