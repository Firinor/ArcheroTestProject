using UnityEngine;

namespace PlayerBehavior
{
    [CreateAssetMenu(fileName = "AttackUnitBehavior", menuName = "GameScriptable/UnitBehaviors/AttackUnitBehavior")]
    public class Attack : PlayerBehavior
    {
        [Header("Behavior transitions")]
        [SerializeField]
        private PlayerBehavior idle;
        [SerializeField]
        private PlayerBehavior move;

        public override void Update()
        {
            if (player.IsJoystickDirection())
            {
                player.SetBehavior(move);
                return;
            }
                

            if (!player.IsAnyEnemy())
            {
                player.SetBehavior(idle);
                return;
            }

            player.FindEnemy();
            player.LookAtEnemy();
            player.Attack();
        }
    }
}

