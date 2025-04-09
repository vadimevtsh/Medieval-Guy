using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class CanvasFactory
{
    private const string CanvasPrefabFolder = "GUI";

    private static List<GameObject> _prefabs;

    private static List<GameObject> Prefabs
    {
        get
        {
            if (_prefabs == null)
            {
                _prefabs = Resources.LoadAll<GameObject>($"{CanvasPrefabFolder}").ToList();
            }

            return _prefabs;
        }
    }

    public static T Build<T>(GameObject root)
        where T : UICanvas
    {
        return BuildOverlay<T>(root);
    }

    private static T BuildOverlay<T>(GameObject root)
        where T : UICanvas
    {
        var canvasPrefab = LoadCanvasPrefab(typeof(T).Name);
        if (canvasPrefab == null)
            return null;

        // Instantiate Prefab.
        var canvasGo = GameObject.Instantiate(canvasPrefab, parent: root?.transform);
        canvasGo.name = canvasPrefab.name;

        var canvas = canvasGo.GetComponent<T>();
        return canvas;
    }

    private static GameObject LoadCanvasPrefab(string canvasType)
    {
        var prefab = Prefabs.FirstOrDefault(p => p.name == canvasType);

        if (prefab == null)
        {
            UnityEngine.Debug.LogError($"CanvasBuilder: Unable to load prefab for canvas type: {canvasType}");
            return null;
        }

        return prefab;
    }

}