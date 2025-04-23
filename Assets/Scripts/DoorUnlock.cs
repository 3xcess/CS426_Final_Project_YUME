using UnityEngine;

public class DoorDestroy : MonoBehaviour
{
    public string uniqueID;

    void Start(){
        if(GameManager.Instance.checkDisabled(uniqueID)){
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.checkKeys()){
            GameManager.Instance.useKey();
            GameManager.Instance.nowDisabled(uniqueID);
            gameObject.SetActive(false);
        }
    }
}
