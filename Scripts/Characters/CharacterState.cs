using DungeonRPG.Scripts.Helper;
using Godot;

public abstract partial class CharacterState : Node
{
    protected Player _playerNode;
    
    public override void _Ready()
    {
        // Disable the physics process unless its the current state
        SetPhysicsProcess(false);
    }


    public override void _Notification(int what)
    {
        base._Notification(what);

        // Listen to any change in the current state and enable physics process
        if (what == NotificationConsts.ENTER_STATE)
        {
            EnterCurrentState();
            SetPhysicsProcess(true);
        }

        // Listen to the notification of disabling the previouse state
        if (what == NotificationConsts.EXIT_STATE)
        {
            SetPhysicsProcess(false);
        }
    }


    protected virtual void EnterCurrentState() { }
}
