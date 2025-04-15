using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private ConfigurationService ConfigurationService => Services.Configuration;

    public List<ItemConfiguration> CurrentItems { get; set; } = new List<ItemConfiguration>();

    public event Action InventoryChanged;

    public void Initialize()
    {
    }

    public void AddItem(string itemId)
    {
        var item = ConfigurationService.ItemProviderService.GetAll().FirstOrDefault(i => i.Id == itemId);
        
        CurrentItems.Add(item);
        
        InventoryChanged?.Invoke();
    }
}

