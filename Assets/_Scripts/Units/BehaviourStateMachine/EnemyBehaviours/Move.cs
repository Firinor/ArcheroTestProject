using UnityEngine;

namespace EnemyBehavior
{
    [CreateAssetMenu(fileName = "EnemyMoveUnitBehavior", menuName = "GameScriptable/UnitBehaviors/EnemyMoveUnitBehavior")]
    public class Move : EnemyBehavior
    {
        public override void Update()
        {
            //Debug.Log(unit.moveVector);
            Vector3 unitPosition = unit.transform.position;
            Vector3 unitDirection = new Vector3(unit.MovePoint.x, 0, unit.MovePoint.y);

            unit.NavMeshAgent.SetDestination(unitPosition + unitDirection);
        }
    }
}