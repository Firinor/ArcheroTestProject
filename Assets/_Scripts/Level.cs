using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Player Player;
    public List<Enemy> Enemies;

    private void Awake()
    {
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

    private void EnemyDeath(Unit dyingEnemy)
    {
        if(dyingEnemy is Enemy enemy)
            Enemies.Remove(enemy);
    }


    private void GameOver(Unit dyungPlayer)
    {
        Debug.LogError("Game Over!");
    }
}
