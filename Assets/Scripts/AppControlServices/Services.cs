using UnityEngine;

public static class Services
{
    public static InputController InputController { get; set; }
    public static PlayerController PlayerController { get; set; }
    public static PrefabProvider PrefabProvider { get; set; }
    
    public static void InitializeCoreSystems()
    {
        PrefabProvider = GetComponentFromScene<PrefabProvider>();
        
        InputController = GetComponentFromScene<InputController>();
        InputController.Initialize();

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
