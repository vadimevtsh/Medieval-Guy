using UnityEngine;

public static class Services
{
    public static void InitializeCoreSystems()
    {
    }
    
    private static T GetComponentFromScene<T>() where T : Object 
    {
        var component = GameObject.FindObjectOfType<T>(includeInactive: true);

        if (component == null) {
            UnityEngine.Debug.LogWarning($"Unable to find component {typeof(T)} on the scene");
        }

        return component;
    }
}
