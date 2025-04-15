using UnityEngine;
using UnityEngine.UI;

public class InventoryItemUI : MonoBehaviour
{
    [SerializeField] private Image _image;
    
    public ItemState ItemState { get; private set; }

    private SpriteProvider SpriteProvider => Services.SpriteProvider;

    public void Initialize(ItemState itemState)
    {
        ItemState = itemState;
        _image.sprite = SpriteProvider.Get(itemState.Configuration.IconName);
    }
}
