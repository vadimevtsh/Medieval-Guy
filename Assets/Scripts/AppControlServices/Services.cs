using UnityEngine;

public static class Services
{
    public static InputController InputController { get; private set; }
    public static PlayerController PlayerController { get; private set; }
    public static PrefabProvider PrefabProvider { get; private set; }
    public static SpriteProvider SpriteProvider { get; private set; }
    public static ConfigurationService Configuration { get; private set; }
    public static InventoryController InventoryController { get; private set; }
    public static InteractionController InteractionController { get; private set; }
    public static WorldOverlayCanvas WorldOverlayCanvas { get; private set; }
    public static OverlayMediator OverlayMediator { get; private set; }
    
    public static void InitializeCoreSystems()
    {
        Configuration = new ConfigurationService();
        Configuration.Initialize(false, string.Empty);
        
        PrefabProvider = GetComponentFromScene<PrefabProvider>();
        SpriteProvider = GetComponentFromScene<SpriteProvider>();
        
        InventoryController = GetComponentFromScene<InventoryController>();
        InventoryController.Initialize();
        
        OverlayMediator = GetComponentFromScene<OverlayMediator>();
        OverlayMediator.Initialize();
        
        WorldOverlayCanvas = GetComponentFromScene<WorldOverlayCanvas>();
        
        InteractionController = GetComponentFromScene<InteractionController>();
        InteractionController.Initialize();
        
        InputController = GetComponentFromScene<InputController>();
        InputController.Initialize();

        PlayerController = GetComponentFromScene<PlayerController>();
        PlayerController.Initialize();
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
