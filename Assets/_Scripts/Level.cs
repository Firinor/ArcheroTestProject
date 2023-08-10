using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    //[HideInInspector]
    public Player Player;
    //[HideInInspector]
    public List<Enemy> Enemies;
    [SerializeField]
    private Transform UnitHolder;
    [SerializeField]
    private DoorKeeper doorKeeper;

    private void Awake()
    {
        GameManager.CurrentLevel++;
        doorKeeper.RefreshLevelText();
        SubscribeToPlayer();
        SubscribeToEnemy();
    }

    private void SubscribeToPlayer()
    {
        Player = UnitHolder.GetComponentInChildren<Player>();
        Player.OnDeath += GameOver;
    }

    private void SubscribeToEnemy()
    {
        Enemies = new List<Enemy>(UnitHolder.GetComponentsInChildren<Enemy>());
        foreach (var enemy in Enemies)
            enemy.OnDeath += EnemyDeath;
    }

    private void EnemyDeath(Unit dyingEnemy)
    {
        if(dyingEnemy is Enemy enemy)
            Enemies.Remove(enemy);

        if (Enemies.Count == 0)
            LevelComplete();
    }


    private void GameOver(Unit dyungPlayer)
    {
        Debug.LogError("Game Over!");
    }

    private void LevelComplete()
    {
        doorKeeper.OpenDoor();
    }
}
