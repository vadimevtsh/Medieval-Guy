using System.Collections.Generic;
using System.Linq;

public class QuestProviderService : IQuestProviderService
{
    private QuestLibrary _library;
    private ConfigurationGroupProxy<QuestConfiguration> _configurationGroup;
    
    public void Initialize(IConfigurationLoader loader) 
    {
        _configurationGroup = loader.QuestGroup;
        _library = loader.Get<QuestLibrary>();
    }
    
    public IEnumerable<QuestConfiguration> GetAll() 
    {
        var configs = _configurationGroup.GetAll();
        var inGameData = _library.QuestsData;
        
        foreach (var gameData in inGameData) 
        {
            var realConfig = configs.FirstOrDefault(c => c.Id == gameData.Id);
            if (realConfig != null) 
            {
                yield return realConfig;
            }
        }
    }
}
