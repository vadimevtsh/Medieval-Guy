using UnityEngine;
using UnityEngine.UI;

public class EntityUpperPanelMV : MonoBehaviour
{
    [SerializeField] private Slider _actionSlider;
    [SerializeField] private Slider _healthBarSlider;
    
    public EntityObject EntityObject { get; set; }

    public void Initialize(EntityObject entity)
    {
        EntityObject = entity;
    }

    public void Update()
    {
        _actionSlider.normalizedValue = EntityObject.Entity.NormalizedActionValue;
    }
}
