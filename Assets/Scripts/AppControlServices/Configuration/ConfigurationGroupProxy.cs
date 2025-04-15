using System.Collections.Generic;
using System.IO;

public class ConfigurationGroupProxy<T> : ConfigurationProxy where T : IConfiguration 
{
    private string _allVariantPathes;
    private string _defaultFolderPath;
    private string _groupFolderPath;

    private readonly List<T> _unboxedCollection = new List<T>();

    public ConfigurationGroupProxy(string rootFolderPath, string defaultFolderPath, string groupFolderPath) 
    {
        _allVariantPathes = rootFolderPath;
        _defaultFolderPath = defaultFolderPath;
        _groupFolderPath = groupFolderPath;

        var defaultPath = Path.Combine(_allVariantPathes, _defaultFolderPath, _groupFolderPath);
        LoadConfiguration<T>(defaultPath);
    }

    public ConfigurationGroupProxy<T> LoadOverride(string groupFolderPath) 
    {
        var overridePath = Path.Combine(_allVariantPathes, groupFolderPath, _groupFolderPath);
        LoadConfiguration<T>(overridePath);
        return this;
    }

    public IEnumerable<T> GetAll() 
    {
        if (_isCollectionDirty) {
            _unboxedCollection.Clear();

            for (int i = 0; i < _configurationCollection.Count; i++) 
            {
                var configuration = _configurationCollection[i];
                if (configuration is T unboxed) 
                {
                    _unboxedCollection.Add(unboxed);
                }
            }
        }

        return _unboxedCollection;
    }
}