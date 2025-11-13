public interface IConfigurationLoader
{
    ConfigurationGroupProxy<EntityConfiguration> EntityGroup { get; }
    ConfigurationGroupProxy<BaseActionConfiguration> ActionGroup { get; }
    
    void InitializeDefault();
    void InitializeOverride(string overrideConfigurationPath);
    T Get<T>() where T : IConfiguration;
}
