using UnityEngine;

public class EntityObject : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    public Entity Entity { get; set; }

    public SpriteProvider SpriteProvider => Services.SpriteProvider;
    
    public void Initialize(Entity entity)
    {
        Entity = entity;

        var sprite = SpriteProvider.Get(Entity.Configuration.SpriteName);
        _spriteRenderer.sprite = sprite;
    }
}
