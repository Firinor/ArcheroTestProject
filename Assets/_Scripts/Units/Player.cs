using UnityEngine;
using Zenject;

public class Player : Unit
{
    [Inject]
    private VisibleFloatingJoystick joystick;
    [SerializeField]
    private UnitBehavior startBehavior;
    [Inject(Id = "Player")]
    private UnitStats stats;

    public override void Awake()
    {
        base.Awake();
        behavior = new UnitBehaviorStateMachine(startBehavior, this);
    }

    private void FixedUpdate()
    {
        MovePoint = joystick.Direction;
        behavior.Update();
    }

    public bool IsJoystickDirection()
    {
        return joystick.Direction.x != 0 || joystick.Direction.y != 0;
    }
}
