using UnityEngine;

public static class Services
{
    private static PlayerController PlayerController { get; set;}
    
    public static void InitializeCoreSystems()
    {
        PlayerController = GetComponentFromScene<PlayerController>();
        PlayerController.Initialize();
    }
    
    private static T GetComponentFromScene<T>() where T : Object 
    {
        var component = GameObject.FindObjectOfType<T>(includeInactive: true);

        if (component == null) {
            Debug.LogWarning($"Unable to find component {typeof(T)} on the scene");
        }

        return component;
    }
}
