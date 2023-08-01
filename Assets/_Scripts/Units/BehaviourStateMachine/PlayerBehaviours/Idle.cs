using UnityEngine;
using Zenject;

namespace PlayerBehavior
{
    [CreateAssetMenu(fileName = "PlayerIdleUnitBehavior", menuName = "GameScriptable/UnitBehaviors/PlayerIdleUnitBehavior")]
    public class Idle : PlayerBehavior
    {
        [Header("Behavior transitions")]
        [SerializeField]
        private PlayerBehavior move;
        [SerializeField]
        private PlayerBehavior attack;

        public override void Update()
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