using UnityEngine;
using UnityEngine.UI;

public class InventoryItemUI : MonoBehaviour
{
    [SerializeField] private Image _image;
    
    public ItemConfiguration ItemConfiguration { get; private set; }

    private SpriteProvider SpriteProvider => Services.SpriteProvider;

    public void Initialize(ItemConfiguration itemConfiguration)
    {
        ItemConfiguration = itemConfiguration;
        _image.sprite = SpriteProvider.Get(itemConfiguration.IconName);
    }
}
