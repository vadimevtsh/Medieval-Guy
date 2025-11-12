using System.Collections.Generic;
using System.Linq;

public class EntityProviderService : IEntityProviderService
{
    private EntityLibrary _entityLibrary;
    private ConfigurationGroupProxy<EntityConfiguration> _configurationGroup;
    
    public void Initialize(IConfigurationLoader loader) 
    {
        _configurationGroup = loader.EntityGroup;
        _entityLibrary = loader.Get<EntityLibrary>();
    }
    
    public IEnumerable<EntityConfiguration> GetAll() 
    {
        var entityConfigs = _configurationGroup.GetAll();
        var inGameEntities = _entityLibrary.EntityData;
        
        foreach (var inGameEntity in inGameEntities) 
        {
            var realConfig = entityConfigs.FirstOrDefault(c => c.Id == inGameEntity.Id);
            if (realConfig != null) 
            {
                yield return realConfig;
            }
        }
    }
}
