using DungeonRPG.Scripts.Helper;
using Godot;
using System;

public partial class PlayerMoveState : PlayerState
{
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


    protected override void EnterCurrentState()
    {
        base.EnterCurrentState();
        _playerNode.AnimationPlayer.Play(PlayerAnimationConsts.MOVE);
    }
}
