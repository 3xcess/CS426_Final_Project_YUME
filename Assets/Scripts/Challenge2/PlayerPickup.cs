using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public Transform holdPoint;       // The transform where the object will be held
    public float pickupRange = 2f;    // How far the player can reach
    public float throwForce = 10f;

    private BlockItem heldItem;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldItem == null)
                TryPickup();
            else
                Throw();
        }
    }

    void TryPickup()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, pickupRange))
        {
            BlockItem block = hit.collider.GetComponent<BlockItem>();
            if (block != null && !block.isHeld)
            {
                heldItem = block;
                heldItem.PickUp(holdPoint);
            }
        }
    }

    void Throw()
    {
        heldItem.Drop(transform.forward * throwForce);
        heldItem = null;
    }
}
