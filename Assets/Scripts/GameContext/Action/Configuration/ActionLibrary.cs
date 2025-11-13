using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Actions Library", menuName = "Actions/Library")]
public class ActionLibrary : ScriptableObject, IConfiguration
{
    public List<BaseActionConfiguration> ActionsData;
}
