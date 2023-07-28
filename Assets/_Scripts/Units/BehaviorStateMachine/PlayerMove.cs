using UnityEngine;


[CreateAssetMenu(fileName = "PlayerMoveUnitBehavior", menuName = "UnitBehaviors/PlayerMoveUnitBehavior")]
public class PlayerMove : UnitBehavior
{
    public override void Update()
    {
        //Debug.Log(unit.moveVector);
        Vector3 unitPosition = unit.transform.position;
        Vector3 unitDirection = new Vector3(unit.MoveVector.x, 0, unit.MoveVector.y);

        unit.NavMeshAgent. SetDestination(unitPosition + unitDirection);
    }
}
