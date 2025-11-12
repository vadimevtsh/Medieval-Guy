public interface IConfigurationLoader
{
    ConfigurationGroupProxy<EntityConfiguration> EntityGroup { get; }
    
    void InitializeDefault();
    void InitializeOverride(string overrideConfigurationPath);
    T Get<T>() where T : IConfiguration;
}
