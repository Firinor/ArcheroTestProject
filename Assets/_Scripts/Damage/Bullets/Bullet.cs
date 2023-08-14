using System;
using UnityEngine;
using Zenject;

namespace Damage
{
    public class Bullet : MonoBehaviour
    {
        [Inject]
        private PackerService packer;
        private AttackData attackData;

        private float lifeTime;
        private float speed;
        private Vector3 direction;
        private string[] tagArray;

        public void Init(AttackData data)
        {
            attackData = data;

            lifeTime = packer.GetParameter<float>(Stat.LifeTime, attackData, isUnsafe: true);
            transform.position = packer.GetParameter<Vector3>(Stat.SpawnPosition, attackData);
            speed = packer.GetParameter<float>(Stat.Speed, attackData);
            Vector3 target = packer.GetParameter<Vector3>(Stat.Target, attackData);
            transform.LookAt(target);
            direction = (target - transform.position).normalized;

            tagArray = packer.GetParameter<string[]>(Stat.Filter, attackData);

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
            if (!Array.Exists(tagArray, filterTag => filterTag == tag))
                return;

            if (other.gameObject.TryGetComponent(out Unit unit))
                unit.TakeHit(attackData);

            Disable();
        }

        private void Disable()
        {
            gameObject.SetActive(false);
            attackData = null;
        }
    }
}
