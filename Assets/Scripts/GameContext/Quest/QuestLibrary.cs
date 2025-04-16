using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest Library", menuName = "Quests/Library")]
public class QuestLibrary : ScriptableObject, IConfiguration
{
    public List<QuestConfiguration> QuestsData;
}
