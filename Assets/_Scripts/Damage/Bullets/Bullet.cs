using UnityEngine;
using System.Linq;
using System;

public class Bullet : MonoBehaviour
{
    public Unit Owner { get; private set; }
    public float damage { get; private set; }
    private float lifeTime;
    private float speed;
    private Vector3 direction;
    private string[] tagMask;


    public void Init(BulletData data)
    {
        //Owner = data.owner;
        //damage = data.damage;
        lifeTime = data.lifeTime;
        //transform.position = data.spawnPosition;
        speed = data.speed;
        //transform.LookAt(data.target);
        //direction = (data.target - data.spawnPosition).normalized;

        //tagMask = data.tagMask;

        gameObject.SetActive(true);
    }

    public void Update()
    {
        transform.localPosition += direction * speed * Time.deltaTime;
    }

    public void FixedUpdate()
    {
        lifeTime -= Time.fixedDeltaTime;
        if (lifeTime <= 0)
            Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;
        if (!Array.Exists(tagMask, mask => mask == tag))
            return;

        if (other.gameObject.TryGetComponent(out Unit unit))
            unit.Damage(damage);

        Disable();
    }



    private void Disable()
    {
        gameObject.SetActive(false);
        Owner = null;
        damage = 0;
    }
}
