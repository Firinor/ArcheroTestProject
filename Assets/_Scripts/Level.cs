using UnityEngine;

public class Level : MonoBehaviour
{
    public Player Player;
    public Enemy[] Enemies;

    private void Awake()
    {
        EnemiesCount = Enemies.Length;
        SubscribeToPlayer();
        SubscribeToEnemy();
    }

    private void SubscribeToPlayer()
    {
        Player.OnDeath += GameOver;
    }

    private void SubscribeToEnemy()
    {
        foreach (var enemy in Enemies)
            enemy.OnDeath += EnemyDeath;
    }

    private void EnemyDeath()
    {
        EnemiesCount--;
    }

    public int EnemiesCount { get; internal set; }

    private void GameOver()
    {
        Debug.LogError("Game Over!");
    }
}
