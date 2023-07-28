using Zenject;

public class Player : Unit
{
    [Inject]
    private VisibleFloatingJoystick joystick;

    private void Awake()
    {
        //behavior = new Move(this);
    }

    private void FixedUpdate()
    {
        MoveVector = joystick.Direction;
        behavior.Update();
    }
}
