using UnityEngine;

public class DestroyableObj : MonoBehaviour
{
    public string uniqueID;

    void Start(){
        if(GameManager.Instance.checkDisabled(uniqueID)){
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player")){
            GameManager.Instance.nowDisabled(uniqueID);
            gameObject.SetActive(false);
        }
    }
}
