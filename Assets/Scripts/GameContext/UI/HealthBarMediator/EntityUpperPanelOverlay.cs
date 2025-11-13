using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityUpperPanelOverlay : UITogglableOverlay
{
    private static Vector3 Offset = new(0, 150, 0);
    
    [SerializeField] private EntityUpperPanelMV _upperPanelPrefab;

    private readonly List<EntityUpperPanelMV> _upperPanels = new();
    
    private EntityMediator EntityMediator => Services.EntityMediator;
    private CameraService CameraService => Services.CameraService;

    public override void Initialize()
    {
        EntityMediator.EntitiesChanged += Synchronize;
    }

    private void Synchronize()
    {
        for (int i = _upperPanels.Count - 1; i >= 0; i--)
        {
            var upperPanel = _upperPanels[i];
            var samePanel = EntityMediator.PlayerEntities.FirstOrDefault(e => e.Entity == upperPanel.EntityObject.Entity);
            if (samePanel == null)
            {
                _upperPanels.Remove(upperPanel);
                Destroy(upperPanel);
            }
        }

        foreach (var entity in EntityMediator.PlayerEntities)
        {
            var sameEntity = _upperPanels.FirstOrDefault(p => p.EntityObject.Entity == entity.Entity);
            if (sameEntity == null)
            {
                var upperPanel = Instantiate(_upperPanelPrefab, transform);
                upperPanel.Initialize(entity);
                
                var position = CameraService.MainCamera.WorldToScreenPoint(entity.gameObject.transform.position) + Offset;
                upperPanel.gameObject.transform.position = position;
                
                _upperPanels.Add(upperPanel);
            }
        }
    }
}
