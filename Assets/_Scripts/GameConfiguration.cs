using UnityEngine;

[CreateAssetMenu(fileName = "GameConfiguration", menuName = "GameScriptable/GameSettings/GameConfiguration")]
public class GameConfiguration : ScriptableObject
{
    public float BulletLifeTime;
    public float BulletSpeed;
}