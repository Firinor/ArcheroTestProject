namespace Abilities
{
    public enum Stat
    {
        HP,
        DEF,
        ATK
    }

    public enum Effect
    {
        Damage,
        ReflectionDamage,
        Heal,
        Debuff
    }

    public enum AttackResultEnum
    {
        IsHit,
        IsBlock,
        IsParry,
        IsDead,
        IsHeald
    }
}
