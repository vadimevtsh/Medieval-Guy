using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player _playerPrefab;
    
    public Player Player { get; private set; }
    
    public void Initialize()
    {
        if (Player == null)
        {
            Player = Instantiate(_playerPrefab, transform);
        }
    }
}
