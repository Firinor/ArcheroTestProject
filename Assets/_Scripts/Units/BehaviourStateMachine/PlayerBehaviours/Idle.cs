using UnityEngine;

namespace PlayerBehavior
{
    [CreateAssetMenu(fileName = "PlayerIdleUnitBehavior", menuName = "GameScriptable/UnitBehaviors/PlayerIdleUnitBehavior")]
    public class Idle : PlayerBehavior
    {
        [Header("Behavior transitions")]
        [SerializeField]
        private PlayerBehavior move;

        public override void Update()
        {
            if (player.IsJoystickDirection())
                player.SetBehavior(move);
        }
    }
}