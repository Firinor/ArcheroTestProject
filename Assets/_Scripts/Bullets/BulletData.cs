using UnityEngine;

public struct BulletData
{
    public IShooter owner;
    public int damage;
    public Vector3 spawnPosition;
    public Vector3 direction;

    public float speed;
    public float lifeTime;

    public BulletData(ShooterData shooterData, float speed, float lifeTime)
    {
        owner = shooterData.owner;
        damage = shooterData.damage;
        spawnPosition = shooterData.spawnPosition;
        direction = shooterData.direction;

        this.speed = speed;
        this.lifeTime = lifeTime;
    }
}