public class Entity
{
    private const float PerformActionTime = 5f;
    
    public EntityConfiguration Configuration { get; private set;}
    public int SlotIndex { get; private set; }

    private float _actionTime = 0f;

    public void Initialize(EntityConfiguration configuration, int slotIndex)
    {
        Configuration = configuration;
        SlotIndex = slotIndex;
    }
    
    public void UpdateAction(float deltaTime)
    {
        _actionTime += deltaTime;
        if (_actionTime > PerformActionTime)
        {
            PerformAction();
            _actionTime = 0f;
        }
    }

    private void PerformAction()
    {
        
    }
}
