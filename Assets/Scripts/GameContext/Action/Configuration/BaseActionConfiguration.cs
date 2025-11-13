using UnityEngine;

public abstract class BaseActionConfiguration : ScriptableObject, IConfiguration
{
    public string Id;
    
    public abstract void Execute(Entity executioner, Entity target);
}
