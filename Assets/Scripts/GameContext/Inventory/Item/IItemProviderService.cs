using System.Collections.Generic;

public interface IItemProviderService
{
    void Initialize(IConfigurationLoader loader);
    IEnumerable<ItemConfiguration> GetAll();
}
