public class ItemState
{
    public ItemConfiguration Configuration { get; private set; }
    private int _slotIndex;

    public void Initialize(ItemConfiguration itemConfiguration, int slotIndex)
    {
        Configuration =itemConfiguration;
        _slotIndex = slotIndex;
    }
}
