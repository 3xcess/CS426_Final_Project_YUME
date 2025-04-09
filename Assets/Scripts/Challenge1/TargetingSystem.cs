using UnityEngine;

public class TargetingSystem : MonoBehaviour
{
    public static TargetingSystem Instance;

    public LayerMask enemyLayer;
    public float maxTargetDistance = 10f;

    private Camera mainCamera;
    private bool isTargetModeActive = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)){
            ToggleTargetMode();
        }
    }

    public void ToggleTargetMode()
    {
        isTargetModeActive = !isTargetModeActive;
        Cursor.visible = isTargetModeActive;
        Cursor.lockState = isTargetModeActive ? CursorLockMode.None : CursorLockMode.Locked;
    }

    // public bool IsAimingAt(GameObject target){
    //     Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f));
    //     RaycastHit hit;
    //     if (Physics.Raycast(ray, out hit, maxTargetDistance, enemyLayer))
    //     {
    //         return hit.collider.gameObject == target;
    //     }
    //     return false;
    // }

    // public GameObject GetTargetedEnemy(){
    //     Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f));
    //     RaycastHit hit;
    //     if (Physics.Raycast(ray, out hit, maxTargetDistance, enemyLayer))
    //     {
    //         return hit.collider.gameObject;
    //     }
    //     return null;
    // }

    public bool IsTargetModeActive()
    {
        return isTargetModeActive;
    }
}