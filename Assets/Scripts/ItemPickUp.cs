using UnityEngine;


public class ItemPickUp : Interactable
{
    public ItemType type;


    public override void Interact(GameObject player)
    {
        Inventory inventory = player.GetComponent<Inventory>();
        inventory.AddItem(type);
        Destroy(gameObject);

    }

    public override string GetToolTip(GameObject player)
    {
        return $"Press E to Pick up {type}";
    }
}
