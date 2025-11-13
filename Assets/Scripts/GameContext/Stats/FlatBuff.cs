public class FlatBuff : IStatModifier
{
    private readonly StatType _type;
    private readonly float _bonus;

    public FlatBuff(StatType type, float bonus)
    {
        _type = type;
        _bonus = bonus;
    }

    public float Modify(StatType type, float currentValue)
    {
        return type == _type ? currentValue + _bonus : currentValue;
    }
}
