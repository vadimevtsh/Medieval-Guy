using System.Collections.Generic;
using UnityEngine;

public class SpriteProvider : MonoBehaviour
{
    private const string ItemFolderPath = "Session/Sprites";
    
    private Dictionary<string, GameObject> _sprites;
    private GameObject _defaultSprite;

    public GameObject Get(string spriteName)
    {
        if (spriteName == null)
        {
            Debug.LogError("SpriteProvider: attempt to load prefab with null prefabName");
            return _defaultSprite;
        }

        if (_sprites == null)
        {
            LoadSprites();
        }

        return _sprites.ContainsKey(spriteName) ? _sprites[spriteName] : _defaultSprite;
    }

    private void LoadSprites()
    {
        _sprites = new Dictionary<string, GameObject>(80);

        var sprites = Resources.LoadAll<GameObject>(ItemFolderPath);

        foreach (var icon in sprites)
        {
            if (icon != null)
            {
                _sprites.Add(icon.name, icon);
            }
        }
    }
}

