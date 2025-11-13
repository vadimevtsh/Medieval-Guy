using System.Collections.Generic;
using System.Linq;
public class Entity : IStatProvider
{
    private const float PerformActionTime = 5f;
    
    private readonly List<IStatModifier> _modifiers = new();
    
    private float _actionTime;
    private float _currentHealth;
    
    private IEnumerable<BaseActionConfiguration> _possibleActions;
    
    public EntityConfiguration Configuration { get; private set;}
    public int SlotIndex { get; private set; }
    public float NormalizedActionValue => _actionTime / PerformActionTime;
    public float NormalizedHealth => _currentHealth / GetStat(StatType.MaxHealth);
    public EntityController EntityController => Services.EntityController;

    public void Initialize(EntityConfiguration configuration, int slotIndex)
    {
        Configuration = configuration;
        SlotIndex = slotIndex;
        _possibleActions = Services.Configuration.ActionProviderService.GetAll();
        
        _currentHealth = GetStat(StatType.MaxHealth);
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

    public void ReceiveDamage(float damage)
    {
        _currentHealth -= damage;
    }

    private void PerformAction()
    {
        var action = _possibleActions.FirstOrDefault(a => a.Id == Configuration.ActionName);
        var target = EntityController.EnemyEntities.FirstOrDefault();
        if (target == null)
        {
            return;
        }
        
        action.Execute(this, target);
    }
}
