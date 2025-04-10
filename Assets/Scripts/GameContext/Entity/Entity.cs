using UnityEngine;

public class Entity : MonoBehaviour
{
    private const float PlayerSpeed = 5f;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Sprite _leftSprite;
    [SerializeField] private Sprite _rightSprite;
    
    public Vector3 Direction { get; set; }

    public void Update()
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
        
        
        transform.position += Direction * PlayerSpeed * Time.deltaTime;
    }
}
