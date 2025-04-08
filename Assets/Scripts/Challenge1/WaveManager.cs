using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance;

    public GameObject hostilePrefab;
    public GameObject hiddenPrefab;
    public GameObject friendlyPrefab;

    public int waveSize = 3;
    public float waveInterval = 15f;
    public float spawnDistanceFromPlayer = 1f;
    public float spawnRadius = 10f;

    private List<GameObject> currentHostileEnemies = new();
    private List<GameObject> currentHiddenEnemies = new();
    private List<GameObject> currentFriendlyEnemies = new();

    private Transform player;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            SpawnWave();
            yield return new WaitForSeconds(waveInterval);
        }
    }

    void SpawnWave()
    {
        ClearCurrentWaveLists();

        Vector3 center = GetValidSpawnPoint();
        SpawnEnemies(friendlyPrefab, 1, currentFriendlyEnemies, center);
        SpawnEnemies(hiddenPrefab, 1, currentHiddenEnemies, center);
        SpawnEnemies(hostilePrefab, 1, currentHostileEnemies, center);
    }

    Vector3 GetValidSpawnPoint()
    {
        Vector2 randomCircle = Random.insideUnitCircle.normalized * spawnDistanceFromPlayer;
        Vector3 point = player.position + new Vector3(randomCircle.x, 0, randomCircle.y);
        NavMeshHit hit;
        if (NavMesh.SamplePosition(point, out hit, 5f, NavMesh.AllAreas))
        {
            return hit.position;
        }
        return point;
    }

    void SpawnEnemies(GameObject prefab, int count, List<GameObject> targetList, Vector3 center){
        int attempts = 0;
        int spawned = 0;

        while (spawned < count){
            attempts++;
            Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
            Vector3 rayOrigin = center + new Vector3(randomOffset.x, 10f, randomOffset.y);
            RaycastHit[] hits = Physics.RaycastAll(rayOrigin, Vector3.down, 50f);

            foreach (RaycastHit hit in hits){

                if (hit.collider.CompareTag("Floor")){
                    NavMeshHit navHit;

                    if (NavMesh.SamplePosition(hit.point, out navHit, 2f, NavMesh.AllAreas)){
                        GameObject enemy = Instantiate(prefab, navHit.position, Quaternion.identity);
                        targetList.Add(enemy);
                        spawned++;
                        break;
                    }
                }
            }
        }
    }

    public void NotifyEnemyDied(GameObject enemy)
    {
        currentHostileEnemies.Remove(enemy);
        currentHiddenEnemies.Remove(enemy);

        if (currentHostileEnemies.Count == 0 && currentHiddenEnemies.Count == 0)
        {
            foreach (GameObject friendly in currentFriendlyEnemies)
            {
                if (friendly != null)
                {
                    friendly.GetComponent<FriendlyEnemy>()?.KillOnWaveClear();
                }
            }
            currentFriendlyEnemies.Clear();
        }
    }

    public void NotifyFriendlyDied(GameObject enemy)
    {
        currentFriendlyEnemies.Remove(enemy);
    }

    public bool OtherEnemiesAttacking()
    {
        return currentHostileEnemies.Count > 0 || currentHiddenEnemies.Count > 0;
    }

    void ClearCurrentWaveLists()
    {
        currentHostileEnemies.Clear();
        currentHiddenEnemies.Clear();
        currentFriendlyEnemies.Clear();
    }
}
