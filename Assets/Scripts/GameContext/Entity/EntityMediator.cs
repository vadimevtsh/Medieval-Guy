using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityMediator : MonoBehaviour
{
    [SerializeField] private EntityObject _entityPrefab;
    [SerializeField] private List<Transform> _entityPositions;
    
    private EntityController EntityController => Services.EntityController;

    private readonly List<EntityObject> _activeEntities = new();
    
    public void Initialize()
    {
        EntityController.PlayerEntitiesChanged += Synchronize;
    }

    private void Synchronize()
    {
        for (int i = _activeEntities.Count - 1; i >= 0; i--)
        {
            var entity = _activeEntities[i];
            var sameEntity = EntityController.PlayerEntities.FirstOrDefault(e => e == entity.Entity);
            if (sameEntity == null)
            {
                _activeEntities.Remove(entity);
                Destroy(entity);
            }
        }

        foreach (var entity in EntityController.PlayerEntities)
        {
            var sameEntity = _activeEntities.FirstOrDefault(e => e.Entity == entity);
            if (sameEntity == null)
            {
                var entityObject = Instantiate(_entityPrefab);
                entityObject.gameObject.transform.position = _entityPositions[entity.SlotIndex].position;
                entityObject.Initialize(entity);
                
                _activeEntities.Add(entityObject);
            }
        }
    }
}
