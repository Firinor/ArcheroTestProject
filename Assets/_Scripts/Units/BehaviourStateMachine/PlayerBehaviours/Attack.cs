using UnityEngine;

namespace PlayerBehavior
{
    [CreateAssetMenu(fileName = "AttackUnitBehavior", menuName = "GameScriptable/UnitBehaviors/AttackUnitBehavior")]
    public class Attack : PlayerBehavior
    {
        public override void Update()
        {
            player.LookAtEnemy();
            if (player.IsReadyToAttack())
            {
                player.Attack();
            }     
        }
    }
}

