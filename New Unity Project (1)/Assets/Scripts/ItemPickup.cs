using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class ItemPickup : Interactable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        
        Debug.Log("Picking up " + item.name);
        // add this to Inventory.
        bool wasPickUp = Inventory.instance.Add(item);
        if(wasPickUp == true)
            Destroy(this.gameObject);
    }
}
