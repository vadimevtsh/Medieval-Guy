using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quests/Quest")]
public class QuestConfiguration : ScriptableObject, IConfiguration
{
    public string Id;
    public List<ItemQuantityPair> Requirements;
    public List<ItemQuantityPair> Rewards;
}

[Serializable]
public struct ItemQuantityPair
{
    public string Id;
    public int Quantity;
}
