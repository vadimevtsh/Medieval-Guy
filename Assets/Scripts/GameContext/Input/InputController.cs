using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private const string GameplayMap = "GameplayMap";
    
    [SerializeField] private InputActionAsset Input;

    private bool _isInitialized = true;
    
    private InputAction _moveUpAction;
    private InputAction _moveDownAction;
    private InputAction _moveLeftAction;
    private InputAction _moveRightAction;

    private Vector3 _movementDirection = Vector2.zero;

    private static PlayerController PlayerController => Services.PlayerController;
    
    public void Initialize()
    {
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
        
        PlayerController.SetInput(_movementDirection);
        
        _movementDirection = Vector3.zero;
    }
}
