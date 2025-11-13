using System.Collections.Generic;
using System.Linq;
public class Entity : IStatProvider
{
    private const float PerformActionTime = 5f;
    
    private readonly List<IStatModifier> _modifiers = new();
    
    public EntityConfiguration Configuration { get; private set;}
    public int SlotIndex { get; private set; }
    public float NormalizedActionValue => _actionTime / PerformActionTime;

    private float _actionTime;

    public void Initialize(EntityConfiguration configuration, int slotIndex)
    {
        Configuration = configuration;
        SlotIndex = slotIndex;
    }
    
    public float GetStat(StatType type)
    {
        var baseStats = Configuration.Stats.FirstOrDefault(s => s.Type == type);
        var value = baseStats.Value;

        foreach (var mod in _modifiers)
        {
            value = mod.Modify(type, value);
        }

        return value;
    }
    
    public void AddModifier(IStatModifier modifier)
    {
        _modifiers.Add(modifier);
    }

    public void RemoveModifier(IStatModifier modifier)
    {
        _modifiers.Remove(modifier);
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
