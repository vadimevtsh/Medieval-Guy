using UnityEngine;

public class Entity : MonoBehaviour
{
    private const float PlayerSpeed = 2.5f;
    private const float IncreasedPlayerSpeed = 5f;

    private static Vector2 DefaultColliderSize = new Vector2(0.28f, 0.28f);
    private static Vector2 SideColliderSize = new Vector2(0.2f, 0.28f);

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private BoxCollider2D _boxCollider2D;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Sprite _leftSprite;
    [SerializeField] private Sprite _rightSprite;
    
    public Vector3 Direction { get; set; }

    private InputController InputController => Services.InputController;

    public void FixedUpdate()
    {
        if (Direction.x < 0)
        {
            _spriteRenderer.sprite = _leftSprite;
            _boxCollider2D.size = SideColliderSize;
        }
        else if (Direction.x > 0)
        {
            _spriteRenderer.sprite = _rightSprite;
            _boxCollider2D.size = SideColliderSize;
        }
        else
        {
            _spriteRenderer.sprite = _defaultSprite;
            _boxCollider2D.size = DefaultColliderSize;
        }

        var speed = InputController.GetShiftHeld() ? IncreasedPlayerSpeed : PlayerSpeed;
        _rigidbody.MovePosition(_rigidbody.position + (Vector2)Direction.normalized * speed * Time.fixedDeltaTime);
    }
}
