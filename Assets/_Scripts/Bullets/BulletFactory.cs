using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    [SerializeField]
    private List<Bullet> bullets;
    [SerializeField]
    private Bullet prefab;

    private Unit mimic;

    public void Create(in Unit owner, int damage, Vector3 direction)
    {
        Bullet result = bullets.Find(b => b.gameObject.activeSelf);

        if (result == null)
            result = Instantiate(prefab);

        mimic = owner;

        mimic.name = null;

        mimic.enabled = false;

        mimic = null;

        owner.name = "";
    }
}
