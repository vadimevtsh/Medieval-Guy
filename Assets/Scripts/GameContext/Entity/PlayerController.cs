using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private InputActionAsset Input;
    
    public Player Player { get; private set; }
    
    public void Initialize()
    {
        if (Player == null)
        {
            Player = Instantiate(_playerPrefab, transform);
        }

        var map = Input.FindActionMap("GameplayMap");
        map.Enable();
    }

    public void Update()
    {
        var moveUp = Input.FindAction("MoveUp");
        var moveDown = Input.FindAction("MoveDown");
        var moveLeft = Input.FindAction("MoveLeft");
        var moveRight = Input.FindAction("MoveRight");
        
        var isMoveUp = moveUp.IsPressed();
        var isMoveDown = moveDown.IsPressed();
        var isMoveLeft = moveLeft.IsPressed();
        var isMoveRight = moveRight.IsPressed();

        if (isMoveUp)
        {
            Player.transform.position += new Vector3(0, 0.01f);
        }
        if (isMoveDown)
        {
            Player.transform.position += new Vector3(0, -0.01f);
        }
        if (isMoveLeft)
        {
            Player.transform.position += new Vector3(-0.01f, 0);
        }
        if (isMoveRight)
        {
            Player.transform.position += new Vector3(0.01f, 0);
        }
    }
}
