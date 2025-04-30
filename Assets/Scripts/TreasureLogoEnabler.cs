using UnityEngine;

public class TreasureLogoEnabler : MonoBehaviour
{
    public string name;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            switch (name){
                case "EC1":
                    GameManager.Instance.foundEC1();
                    break;
                case "EC2":
                    GameManager.Instance.foundEC2();
                    break;
                case "EC3":
                    GameManager.Instance.foundEC3();
                    break;
            }
        }
    }
}
