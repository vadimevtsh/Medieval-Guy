using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "FactoryObjectLibrary", menuName = "FutureGame/Factory/FactoryObjectLibrary")]

public class ItemProviderProviderService : IItemProviderService
{
    private ItemLibrary _itemLibrary;
    private ConfigurationGroupProxy<ItemConfiguration> _configurationGroup;
    
    public void Initialize(IConfigurationLoader loader) 
    {
        _configurationGroup = loader.ItemGroup;
        _itemLibrary = loader.Get<ItemLibrary>();
    }
    
    public IEnumerable<ItemConfiguration> GetAll() 
    {
        var itemConfigs = _configurationGroup.GetAll();
        var inGameItems = _itemLibrary.ItemsData;
        
        foreach (var inGameFactory in inGameItems) 
        {
            var realConfig = itemConfigs.FirstOrDefault(c => c.Id == inGameFactory.Id);
            if (realConfig != null) 
            {
                yield return realConfig;
            }
        }
    }
}
