using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private ConfigurationService ConfigurationService => Services.Configuration;

    public List<ItemState> CurrentItems { get; set; } = new List<ItemState>();

    public event Action InventoryChanged;

    public void Initialize()
    {
    }

    public void AddItem(string itemId)
    {
        var itemConfiguration = ConfigurationService.ItemProviderService.GetAll().FirstOrDefault(i => i.Id == itemId);
        var item = new ItemState();
        item.Initialize(itemConfiguration, CurrentItems.Count - 1);
        
        CurrentItems.Add(item);
        
        InventoryChanged?.Invoke();
    }
}

