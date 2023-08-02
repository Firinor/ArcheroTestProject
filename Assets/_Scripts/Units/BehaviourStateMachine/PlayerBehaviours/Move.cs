using UnityEngine;

namespace PlayerBehavior 
{
    [CreateAssetMenu(fileName = "PlayerMoveUnitBehavior", menuName = "GameScriptable/UnitBehaviors/PlayerMoveUnitBehavior")]
    public class Move : PlayerBehavior
    {
        [Header("Behavior transitions")]
        [SerializeField]
        private PlayerBehavior idle;

        public override void Update()
        {
            if (!player.IsJoystickDirection())
            {
                player.SetBehavior(idle);
                return;
            }

            Vector3 unitPosition = player.transform.position;
            Vector3 unitDirection = new Vector3(player.MovePoint.x, 0, player.MovePoint.y);

            player.NavMeshAgent.SetDestination(unitPosition + unitDirection);
        }

        public override void Exit()
        {
            player.NavMeshAgent.SetDestination(player.transform.position);
        }
    }
}