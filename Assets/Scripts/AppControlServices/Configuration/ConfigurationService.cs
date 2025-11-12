public class ConfigurationService
{
    public IEntityProviderService EntityProviderService { get; private set; } = new EntityProviderService();
    
    private IConfigurationLoader Loader { get; set; } = new ConfigurationLoader();
    
    public void Initialize(bool hasOverride, string overidePath) 
    {
        Loader.InitializeDefault();
        if (hasOverride) 
        {
            Loader.InitializeOverride(overidePath);
        }
        
        EntityProviderService.Initialize(Loader);
    }
}
