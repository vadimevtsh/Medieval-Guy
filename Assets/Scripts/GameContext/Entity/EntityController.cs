using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    public List<Entity> PlayerEntities { get; set; } = new();
    public List<Entity> EnemyEntities { get; set; } = new();

    public event Action PlayerEntitiesChanged;

    private IEntityProviderService EntityConfiguration => Services.Configuration.EntityProviderService;
    
    public void Initialize()
    {
        var configuration = EntityConfiguration.GetAll();
        AddPlayerEntity(configuration.FirstOrDefault(c => c.Id == "Warrior"), PlayerEntities.Count);
        AddPlayerEntity(configuration.FirstOrDefault(c => c.Id == "Warrior"), PlayerEntities.Count);
        AddPlayerEntity(configuration.FirstOrDefault(c => c.Id == "Warrior"), PlayerEntities.Count);
    }
    
    public void Update()
    {
        foreach (var entity in PlayerEntities)
        {
            entity.UpdateAction(Time.deltaTime);
        }

        foreach (var entity in EnemyEntities)
        {
            entity.UpdateAction(Time.deltaTime);
        }
    }

    public void AddPlayerEntity(EntityConfiguration entity, int slotIndex)
    {
        var newEntity = new Entity();
        newEntity.Initialize(entity, slotIndex);
        PlayerEntities.Add(newEntity);
        
        PlayerEntitiesChanged?.Invoke();
    }
}
