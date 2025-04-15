using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string PlayerPrefabName = "MainCharacter";

    private bool _isInitialized;

    public Vector3 PlayerPosition => Player.transform.position;
    
    private Player Player { get; set; }

    private PrefabProvider PrefabProvider => Services.PrefabProvider; 
    
    public void Initialize()
    {
        if (Player == null)
        {
            var playerPrefab = PrefabProvider.Get(PlayerPrefabName).GetComponent<Player>();
            Player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity, transform);
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
