using System.Collections.Generic;
using UnityEngine;

public class PrefabProvider : MonoBehaviour
{
    private const string ItemFolderPath = "Session/Prefabs";

    private Dictionary<string, GameObject> _prefabs;
    private GameObject _defaultPrefab;

    public GameObject Get(string prefabName)
    {
        if (prefabName == null)
        {
            Debug.LogError("PrefabProvider: attempt to load prefab with null prefabName");
            return _defaultPrefab;
        }

        if (_prefabs == null)
        {
            LoadPrefabs();
        }

        return _prefabs.ContainsKey(prefabName) ? _prefabs[prefabName] : _defaultPrefab;
    }

    private void LoadPrefabs()
    {
        _prefabs = new Dictionary<string, GameObject>(40);

        var prefabs = Resources.LoadAll<GameObject>(ItemFolderPath);

        foreach (var icon in prefabs)
        {
            if (icon != null)
            {
                _prefabs.Add(icon.name, icon);
            }
        }
    }
}