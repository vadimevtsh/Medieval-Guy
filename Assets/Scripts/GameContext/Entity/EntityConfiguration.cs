using UnityEngine;

[CreateAssetMenu(fileName = "Entity", menuName = "Entities/Entity")]
public class EntityConfiguration : ScriptableObject, IConfiguration
{
    public string Id;
    public string SpriteName;
}
