using UnityEngine;

[CreateAssetMenu(fileName = "UnitStats", menuName = "Stats/UnitStats")]
public class UnitStats : ScriptableObject
{
    public float Speed;
    public int Health;

    public int Damage;
    public float AttackRate;
}
