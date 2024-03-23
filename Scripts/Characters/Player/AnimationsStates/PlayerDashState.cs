using DungeonRPG.Scripts.Helper;
using Godot;
using System;

public partial class PlayerDashState : Node
{
    private Player _playerNode;

    public override void _Ready()
    {
        _playerNode = GetOwner<Player>();

        // Disable the physics process unless its the current state
        SetPhysicsProcess(false);
    }

    public override void _PhysicsProcess(double delta)
    {
        if (!_playerNode.IsDashing)
        {
            // Switch the animation to idle when the dash is finished
            _playerNode.StateMachine.SwitchState<PlayerIdleState>();
        }
    }


    public override void _Notification(int what)
    {
        base._Notification(what);

        // Listen to any change in the current state and enable physics process
        if (what == 5001)
        {
            _playerNode.AnimationPlayer.Play(AnimationConsts.DASH);
            SetPhysicsProcess(true);
        }
        
        // Listen to the notification of disabling the previouse state
        if (what == 5002)
        {
            SetPhysicsProcess(false);
        }
    }
}
