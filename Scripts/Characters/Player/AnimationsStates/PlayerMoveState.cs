using DungeonRPG.Scripts.Helper;
using Godot;
using System;

public partial class PlayerMoveState : Node
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
        base._PhysicsProcess(delta);

        // Switch to the idle state if movment input is released
        if (_playerNode.InputVector == Vector2.Zero)
        {
            _playerNode.StateMachine.SwitchState<PlayerIdleState>();
        }

        if (_playerNode.IsDashing)
        {
            _playerNode.StateMachine.SwitchState<PlayerDashState>();
        }
    }


    public override void _Notification(int what)
    {
        base._Notification(what);

        // Listen to any change in the current state and enable physics process
        if (what == 5001)
        {
            _playerNode.AnimationPlayer.Play(AnimationConsts.MOVE);
            SetPhysicsProcess(true);
        }

        // Listen to the notification of disabling the previouse state
        if (what == 5002)
        {
            SetPhysicsProcess(false);
        }
    }
}
