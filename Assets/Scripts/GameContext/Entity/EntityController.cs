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

    public void AddPlayerEntity(string id, int slotIndex)
    {
        var configuration = EntityConfiguration.GetAll().FirstOrDefault(c => c.Id == id);
        AddPlayerEntity(configuration, slotIndex);
    }

    public void AddPlayerEntity(EntityConfiguration entityConfiguration, int slotIndex)
    {
        var newEntity = new Entity();
        newEntity.Initialize(entityConfiguration, slotIndex);
        PlayerEntities.Add(newEntity);
        
        PlayerEntitiesChanged?.Invoke();
    }
}
