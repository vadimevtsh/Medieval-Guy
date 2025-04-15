using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Library", menuName = "Items/Library")]
public class ItemLibrary : ScriptableObject, IConfiguration
{
    public List<ItemConfiguration> ItemsData;
}
