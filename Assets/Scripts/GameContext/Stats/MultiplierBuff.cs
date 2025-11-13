public class MultiplierBuff : IStatModifier
{
    private readonly StatType _type;
    private readonly float _multiplier;

    public MultiplierBuff(StatType type, float multiplier)
    {
        _type = type;
        _multiplier = multiplier;
    }

    public float Modify(StatType type, float currentValue)
    {
        return type == _type ? currentValue * _multiplier : currentValue;
    }
}
