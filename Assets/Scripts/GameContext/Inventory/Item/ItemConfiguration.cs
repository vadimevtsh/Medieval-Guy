using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/Item")]
public class ItemConfiguration : ScriptableObject, IConfiguration
{
    public string Id;
    public string PrefabName;
    public string IconName;
    public string Name;
    public string Description;
    public float Price;
}