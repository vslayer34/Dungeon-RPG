using Godot;

public partial class PlayerState : Node
{
    protected Player _playerNode;
    

    public override void _Ready()
    {
        _playerNode = GetOwner<Player>();

        // Disable the physics process unless its the current state
        SetPhysicsProcess(false);
    }


    public override void _Notification(int what)
    {
        base._Notification(what);

        // Listen to any change in the current state and enable physics process
        if (what == 5001)
        {
            EnterCurrentState();
            SetPhysicsProcess(true);
        }

        // Listen to the notification of disabling the previouse state
        if (what == 5002)
        {
            SetPhysicsProcess(false);
        }
    }


    protected virtual void EnterCurrentState() { }
}
