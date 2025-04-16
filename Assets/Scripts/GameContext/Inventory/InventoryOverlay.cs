using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryOverlay : UITogglableOverlay
{
    [SerializeField] private Transform _itemsParent;
    [SerializeField] private InventoryItemUI _inventoryItemPrefab;
    
    private List<InventoryItemUI> _inventoryItems = new List<InventoryItemUI>();

    private InventoryController InventoryController => Services.InventoryController;
    
    public override void Initialize()
    {
        base.Initialize();

        InventoryController.InventoryChanged += Synchronize;
    }
    
    private void OnDestroy()
    {
        InventoryController.InventoryChanged -= Synchronize;
    }
    
    private void Synchronize()
    {
        var items = InventoryController.CurrentItems;
        for (int i = _inventoryItems.Count - 1; i >= 0; i --)
        {
            var inventoryItem = _inventoryItems[i];
            var sameItem = items.FirstOrDefault(itemState => itemState == inventoryItem.ItemState);
            if (sameItem != null)
            {
                continue;
            }

            _inventoryItems.Remove(inventoryItem);
            Destroy(inventoryItem.gameObject);
        }
        
        foreach (var item in items)
        {
            var sameItem = _inventoryItems.FirstOrDefault(i => i.ItemState == item);
            if (sameItem != null)
            {
                continue;
            }
                
            var newItem = Instantiate(_inventoryItemPrefab, _itemsParent);
            newItem.Initialize(item);
            
            _inventoryItems.Add(newItem);
        }
    }
}
