using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    [SerializeField]
    private List<Bullet> bullets;
    [SerializeField]
    private Bullet prefab;

    public void Create(BulletData data)
    {
        Bullet result = bullets.Find(b => !b.gameObject.activeSelf);

        if (result == null)
        {
            result = Instantiate(prefab);
            bullets.Add(result);
        }
            

    }
}