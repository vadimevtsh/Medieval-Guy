using UnityEngine;

public static class Services
{
    public static PrefabProvider PrefabProvider { get; private set; }
    public static SpriteProvider SpriteProvider { get; private set; }
    public static WorldOverlayCanvas WorldOverlayCanvas { get; private set; }
    public static OverlayMediator OverlayMediator { get; private set; }
    public static EntityController EntityController { get; private set; }
    public static EntityMediator EntityMediator { get; private set; }
    public static ConfigurationService Configuration { get; private set; }
    
    public static void InitializeCoreSystems()
    {
        Configuration = new ConfigurationService();
        Configuration.Initialize(false, string.Empty);
        
        PrefabProvider = GetComponentFromScene<PrefabProvider>();
        SpriteProvider = GetComponentFromScene<SpriteProvider>();
        
        OverlayMediator = GetComponentFromScene<OverlayMediator>();
        OverlayMediator.Initialize();
        
        WorldOverlayCanvas = GetComponentFromScene<WorldOverlayCanvas>();

        EntityController = GetComponentFromScene<EntityController>();
        EntityMediator = GetComponentFromScene<EntityMediator>();
        EntityMediator.Initialize();
        EntityController.Initialize();
    }
    
    private static T GetComponentFromScene<T>() where T : Object 
    {
        var component = GameObject.FindObjectOfType<T>(includeInactive: true);

        if (component == null) 
        {
            Debug.LogWarning($"Unable to find component {typeof(T)} on the scene");
        }

        return component;
    }
}
