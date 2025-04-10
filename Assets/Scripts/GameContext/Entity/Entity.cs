using UnityEngine;

public class Entity : MonoBehaviour
{
    private const float PlayerSpeed = 5f;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Sprite _leftSprite;
    [SerializeField] private Sprite _rightSprite;
    
    public Vector3 Direction { get; set; }

    public void FixedUpdate()
    {
        if (Direction.x < 0)
        {
            _spriteRenderer.sprite = _leftSprite;
        }
        else if (Direction.x > 0)
        {
            _spriteRenderer.sprite = _rightSprite;
        }
        else
        {
            _spriteRenderer.sprite = _defaultSprite;
        }
        
        _rigidbody.MovePosition(_rigidbody.position + (Vector2)Direction.normalized * PlayerSpeed * Time.fixedDeltaTime);
    }
}
