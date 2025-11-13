using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Entity", menuName = "Entities/Entity")]
public class EntityConfiguration : ScriptableObject, IConfiguration
{
    public string Id;
    public string SpriteName;
    public List<StatEntry> Stats = new();
    
    private void OnValidate()
    {
        var allTypes = Enum.GetValues(typeof(StatType)).Cast<StatType>();
        foreach (var type in allTypes)
        {
            if (Stats.All(s => s.Type != type))
            {
                Stats.Add(new StatEntry { Type = type, Value = 0 });
            }
        }
        
        Stats = Stats.OrderBy(s => s.Type).ToList();
    }
}

[System.Serializable]
public class StatEntry
{
    public StatType Type;
    public float Value;
}

public enum StatType
{
    MaxHealth,
    Damage,
    Defense,
    CritChance,
    AttackSpeed
}
