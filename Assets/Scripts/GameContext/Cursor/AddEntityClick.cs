using UnityEngine;

public class AddEntityClick : MonoBehaviour, IClickHandler
{
    [SerializeField] private string _entityId;
    [SerializeField] private int _slotIndex;

    private bool _isSpawned;
    
    private EntityController EntityController => Services.EntityController;

    public void OnClick()
    {
        if (_isSpawned)
        {
            return;
        }
        
        EntityController.AddPlayerEntity(_entityId, _slotIndex);

        _isSpawned = true;
    }
}
