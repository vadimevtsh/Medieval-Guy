using UnityEngine;

public class GroundItem : Interactable
{
    [SerializeField] private string Id;

    private InventoryController InventoryController => Services.InventoryController;
    
    public override void Interact()
    {
        InventoryController.AddItem(Id);
        
        Destroy(gameObject);
    }
}
