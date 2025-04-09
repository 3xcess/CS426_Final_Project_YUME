using UnityEngine;

public class BlockItem : MonoBehaviour
{
    [HideInInspector] public bool isHeld = false;

    public void PickUp(Transform holdParent)
    {
        isHeld = true;
        GetComponent<Rigidbody>().isKinematic = true;
        transform.SetParent(holdParent);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    public void Drop(Vector3 throwForce)
    {
        isHeld = false;
        transform.SetParent(null);
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(throwForce, ForceMode.Impulse);
    }
}
