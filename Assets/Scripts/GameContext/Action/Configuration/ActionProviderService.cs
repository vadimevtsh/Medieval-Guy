using System.Collections.Generic;
using System.Linq;

public class ActionProviderService : IActionProviderService
{
    private ActionLibrary _library;
    private ConfigurationGroupProxy<BaseActionConfiguration> _configurationGroup;
    
    public void Initialize(IConfigurationLoader loader) 
    {
        _configurationGroup = loader.ActionGroup;
        _library = loader.Get<ActionLibrary>();
    }
    
    public IEnumerable<BaseActionConfiguration> GetAll() 
    {
        var configs = _configurationGroup.GetAll();
        var inGameActions = _library.ActionsData;
        
        foreach (var inGameAction in inGameActions) 
        {
            var realConfig = configs.FirstOrDefault(c => c.Id == inGameAction.Id);
            if (realConfig != null) 
            {
                yield return realConfig;
            }
        }
    }
}
