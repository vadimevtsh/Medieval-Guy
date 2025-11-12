using System.Collections.Generic;

public interface IEntityProviderService 
{
    void Initialize(IConfigurationLoader loader);
    IEnumerable<EntityConfiguration> GetAll();
}
