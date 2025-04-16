using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ConfigurationLoader : ConfigurationProxy, IConfigurationLoader
{
    private const string RootConfigurationPath = "ScriptableObjects";
    private const string DefaultConfigurationPath = "Default";
    
    private const string ConfigManifestFilePath = "ScriptableObjects/ConfigManifest";

    private static readonly List<string> _overridesVariants = new();

    public static string DefaultConfigPath => DefaultConfigurationPath;
    public static List<string> OverridesVariants => _overridesVariants;

    public ConfigurationGroupProxy<ItemConfiguration> ItemGroup { get; private set; }
    public ConfigurationGroupProxy<QuestConfiguration> QuestGroup { get; private set; }
    
    public ConfigurationLoader() 
    {
        var configManifest = Resources.Load<TextAsset>(ConfigManifestFilePath);
        var foldersInManifest = configManifest.text.Split("\r\n");

        foreach (var folderName in foldersInManifest) 
        {
            if (folderName == string.Empty) 
            {
                continue;
            }
            
            _overridesVariants.Add(folderName);
        }
    }
    
    public void InitializeDefault() 
    {
        _configurationCollection.Clear();

        var defaultConfigPath = Path.Combine(RootConfigurationPath, DefaultConfigurationPath);
        LoadConfiguration<IConfiguration>(defaultConfigPath);

        ItemGroup = new ConfigurationGroupProxy<ItemConfiguration>(RootConfigurationPath, DefaultConfigurationPath, "Items");
        QuestGroup = new ConfigurationGroupProxy<QuestConfiguration>(RootConfigurationPath, DefaultConfigurationPath, "Quests");
    }
  
    public void InitializeOverride(string overrideConfigurationPath) 
    {
        var overridenPath = Path.Combine(RootConfigurationPath, overrideConfigurationPath);
        LoadConfiguration<IConfiguration>(overridenPath);

        ItemGroup.LoadOverride(overrideConfigurationPath);
        QuestGroup.LoadOverride(overrideConfigurationPath);
    }

    public T Get<T>() where T : IConfiguration 
    {
        return GetConfig<T>();
    }
}
