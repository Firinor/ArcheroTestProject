using UnityEngine;

namespace PlayerBehaviourNamespace
{
    [CreateAssetMenu(fileName = "PlayerIdleUnitBehavior", menuName = "GameScriptable/UnitBehaviors/PlayerIdleUnitBehavior")]
    public class Idle : PlayerBehavior
    {
        [Header("Behavior transitions")]
        [SerializeField]
        private PlayerBehavior move;
        [SerializeField]
        private PlayerBehavior attack;

        public override void Tick(Player player)
        {
            if (player.IsJoystickDirection())
            {
                player.SetBehavior(move);
                return;
            }


            if (player.IsAnyEnemy())
            {
                player.SetBehavior(attack);
                return;
            }
        }
    }
}