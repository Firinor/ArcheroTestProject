using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour
{
    [Inject]
    private GameConfiguration configuration;
    public Unit Owner;

    public void Init(Unit owner)
    {
        Owner = owner;
    }

}
