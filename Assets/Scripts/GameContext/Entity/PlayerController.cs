using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player _playerPrefab;

    private bool _isInitialized;
    
    public Player Player { get; private set; }
    
    public void Initialize()
    {
        if (Player == null)
        {
            Player = Instantiate(_playerPrefab, Vector3.zero, Quaternion.identity, transform);
        }

        _isInitialized = true;
    }

    public void SetInput(Vector3 movementDirection)
    {
        if (!_isInitialized)
        {
            return;
        }

        Player.Direction = movementDirection;
    }
}
