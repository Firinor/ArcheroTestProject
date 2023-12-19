using UnityEngine;

[CreateAssetMenu(fileName = "UnitStats", menuName = "GameScriptable/Stats/UnitStats")]
public class UnitStats : ScriptableObject
{
    public float Speed;
    public int Health;

    public float Damage;
    public float AttackRate;

    public string EnemyTag;
    public string EnemyLayer;
}
