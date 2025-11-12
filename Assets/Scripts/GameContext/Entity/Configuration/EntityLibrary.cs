using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Entity Library", menuName = "Entities/Library")]
public class EntityLibrary : ScriptableObject, IConfiguration
{
    public List<EntityConfiguration> EntityData;
}
