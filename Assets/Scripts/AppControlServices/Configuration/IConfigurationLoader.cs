public interface IConfigurationLoader
{
    ConfigurationGroupProxy<ItemConfiguration> ItemGroup { get; }
    ConfigurationGroupProxy<QuestConfiguration> QuestGroup { get; }

    void InitializeDefault();
    void InitializeOverride(string overrideConfigurationPath);
    T Get<T>() where T : IConfiguration;
}
