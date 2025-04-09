using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private const string GameplayMap = "GameplayMap";
    private const float PlayerSpeed = 5f;
    
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private InputActionAsset Input;

    private bool _isInitialized = true;
    
    private InputAction _moveUpAction;
    private InputAction _moveDownAction;
    private InputAction _moveLeftAction;
    private InputAction _moveRightAction;

    private Vector3 _movementDirection = Vector2.zero; 
    
    public Player Player { get; private set; }
    
    public void Initialize()
    {
        if (Player == null)
        {
            Player = Instantiate(_playerPrefab, transform);
        }

        Input.FindActionMap(GameplayMap).Enable();
        
        _moveUpAction = Input.FindAction("MoveUp");
        _moveDownAction = Input.FindAction("MoveDown");
        _moveLeftAction = Input.FindAction("MoveLeft");
        _moveRightAction = Input.FindAction("MoveRight");

        _isInitialized = true;
    }

    public void Update()
    {
        if (!_isInitialized)
        {
            return;
        }
        
        var isMoveUp = _moveUpAction.IsPressed();
        var isMoveDown = _moveDownAction.IsPressed();
        var isMoveLeft = _moveLeftAction.IsPressed();
        var isMoveRight = _moveRightAction.IsPressed();
        
        if (isMoveUp && isMoveDown)
        {
            _movementDirection.y = 0;
        }
        if (isMoveUp)
        {
            _movementDirection.y = 1;
        }
        if (isMoveDown)
        {
            _movementDirection.y = -1;
        }
        
        if (isMoveLeft && isMoveRight)
        {
            _movementDirection.x = 0;
        }
        if (isMoveLeft)
        {
            _movementDirection.x = -1;
        }
        if (isMoveRight)
        {
            _movementDirection.x = 1;
        }

        Player.transform.position += _movementDirection * PlayerSpeed * Time.deltaTime;
        _movementDirection = Vector3.zero;
    }
}
