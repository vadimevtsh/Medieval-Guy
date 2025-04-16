using System.Collections.Generic;

public interface IQuestProviderService
{
    void Initialize(IConfigurationLoader loader);
    IEnumerable<QuestConfiguration> GetAll();
}
