using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConfigurationProxy
{
    protected readonly List<IConfiguration> _configurationCollection = new();
    protected bool _isCollectionDirty;
    
    public T GetConfig<T>() where T : IConfiguration 
    {
        var neededConfig = _configurationCollection.FirstOrDefault(c => c.GetType() == typeof(T));
        if (neededConfig == null)
        {
            Debug.LogError($"ConfigurationService: Unable to find configuration that is type of {typeof(T)}");
        }

        return (T)neededConfig;
    }
    
    protected void LoadConfiguration<T>(string configurationPath) where T : IConfiguration 
    {
        var allScriptables = Resources.LoadAll(configurationPath);
        foreach (var file in allScriptables) 
        {
            if (file is not T configuration) 
            {
                continue;
            }

            var alreadyAddedConfig = _configurationCollection.FirstOrDefault(c => c.name == configuration.name);
            if (alreadyAddedConfig != null) 
            {
                _configurationCollection.Remove(alreadyAddedConfig);
            }
            _configurationCollection.Add(configuration);

            _isCollectionDirty = true;
        }
    }
}
