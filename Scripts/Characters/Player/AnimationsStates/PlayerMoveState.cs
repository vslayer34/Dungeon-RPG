using DungeonRPG.Scripts.Helper;
using Godot;
using System;

public partial class PlayerMoveState : Node
{
    private Player _playerNode;

    public override void _Ready()
    {
        _playerNode = GetOwner<Player>();
        _playerNode.AnimationPlayer.Play(AnimationConsts.MOVE);
    }


    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        // Switch to the idle state if movment input is released
        if (_playerNode.InputVector == Vector2.Zero)
        {
            _playerNode.StateMachine.SwitchState<PlayerIdleState>();
        }
    }


    public override void _Notification(int what)
    {
        base._Notification(what);

        // Listen to any change in the current state
        if (what == 5001)
        {
            _playerNode.AnimationPlayer.Play(AnimationConsts.MOVE);
        }
    }
}
