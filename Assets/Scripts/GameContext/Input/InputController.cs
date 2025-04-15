using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private const string GameplayMap = "GameplayMap";
    
    [SerializeField] private InputActionAsset _input;

    private bool _isInitialized = true;
    
    private InputAction _moveUpAction;
    private InputAction _moveDownAction;
    private InputAction _moveLeftAction;
    private InputAction _moveRightAction;
    private InputAction _shiftAction;

    private Vector3 _movementDirection = Vector2.zero;

    private PlayerController PlayerController => Services.PlayerController;
    private ConfigurationService ConfigurationService => Services.Configuration;
    
    public void Initialize()
    {
        _input.FindActionMap(GameplayMap).Enable();
        
        _moveUpAction = _input.FindAction("MoveUp");
        _moveDownAction = _input.FindAction("MoveDown");
        _moveLeftAction = _input.FindAction("MoveLeft");
        _moveRightAction = _input.FindAction("MoveRight");
        _shiftAction = _input.FindAction("Shift");

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
        else if (isMoveUp)
        {
            _movementDirection.y = 1;
        }
        else if (isMoveDown)
        {
            _movementDirection.y = -1;
        }
        
        if (isMoveLeft && isMoveRight)
        {
            _movementDirection.x = 0;
        }
        else if (isMoveLeft)
        {
            _movementDirection.x = -1;
        }
        else if (isMoveRight)
        {
            _movementDirection.x = 1;
        }
        
        PlayerController.SetInput(_movementDirection);
        
        _movementDirection = Vector3.zero;
    }

    public bool GetShiftHeld()
    {
        return _shiftAction.IsPressed();
    }
}
