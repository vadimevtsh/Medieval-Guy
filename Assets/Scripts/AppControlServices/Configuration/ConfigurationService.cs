public class ConfigurationService
{
    public IItemProviderService ItemProviderService { get; private set; } = new ItemProviderService();
    public IQuestProviderService QuestProviderService { get; private set; } = new QuestProviderService();
    
    private IConfigurationLoader Loader { get; set; } = new ConfigurationLoader();
    
    public void Initialize(bool hasOverride, string overidePath) 
    {
        Loader.InitializeDefault();
        if (hasOverride) 
        {
            Loader.InitializeOverride(overidePath);
        }
        
        ItemProviderService.Initialize(Loader);
        QuestProviderService.Initialize(Loader);
    }
}
