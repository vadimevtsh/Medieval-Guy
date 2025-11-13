using System.Collections.Generic;

public interface IActionProviderService
{
    void Initialize(IConfigurationLoader loader);
    IEnumerable<BaseActionConfiguration> GetAll();
}
