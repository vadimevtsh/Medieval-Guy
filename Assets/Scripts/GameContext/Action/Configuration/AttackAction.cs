using UnityEngine;

[CreateAssetMenu(fileName = "Attack Action", menuName = "Actions/Attack")]
public class AttackAction : BaseActionConfiguration
{
    public float Damage;

    public override void Execute(Entity executioner, Entity target)
    {
        target.ReceiveDamage(Damage);
    }
}
