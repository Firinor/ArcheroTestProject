using UnityEngine;

namespace PlayerBehavior 
{
    [CreateAssetMenu(fileName = "PlayerMoveUnitBehavior", menuName = "UnitBehaviors/PlayerMoveUnitBehavior")]
    public class Move : PlayerBehavior
    {
        [Header("Behavior transitions")]
        [SerializeField]
        private PlayerBehavior idle;

        public override void Update()
        {
            if (!player.IsJoystickDirection())
                player.SetBehavior(idle);

            //Debug.Log(unit.moveVector);
            Vector3 unitPosition = player.transform.position;
            Vector3 unitDirection = new Vector3(player.MovePoint.x, 0, player.MovePoint.y);

            player.NavMeshAgent.SetDestination(unitPosition + unitDirection);
        }
    }
}