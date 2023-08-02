using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour
{
    public IShooter Owner { get; private set; }
    public float damage { get; private set; }
    private float lifeTime;
    private float speed;
    private Vector3 direction;


    public void Init(BulletData data)
    {
        Owner = data.owner;
        damage = data.damage;
        lifeTime = data.lifeTime;
        transform.position = data.spawnPosition;
        speed = data.speed;
        transform.LookAt(data.target);
        direction = (data.target - data.spawnPosition).normalized;

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

    private void Disable()
    {
        gameObject.SetActive(false);
        Owner = null;
        damage = 0;
    }
}
