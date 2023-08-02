﻿using UnityEngine;

public struct BulletData
{
    public IShooter owner;
    public int damage;
    public Vector3 spawnPosition;
    public Vector3 target;

    public float speed;
    public float lifeTime;
    public string[] tagMask;

    public BulletData(ShooterData shooterData, float speed, float lifeTime)
    {
        owner = shooterData.owner;
        damage = shooterData.damage;
        spawnPosition = shooterData.spawnPosition;
        target = shooterData.target;
        tagMask = shooterData.tagMask;

        this.speed = speed;
        this.lifeTime = lifeTime;
    }
}