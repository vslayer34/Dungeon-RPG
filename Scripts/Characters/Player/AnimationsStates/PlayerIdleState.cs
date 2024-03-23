using DungeonRPG.Scripts.Helper;
using Godot;
using System;

public partial class PlayerIdleState : PlayerState
{
    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        
        // Change the state to move state when movment input is pressed
        if (_playerNode.InputVector != Vector2.Zero)
        {
            _playerNode.StateMachine.SwitchState<PlayerMoveState>();
        }
        
        if (_playerNode.IsDashing)
        {
            _playerNode.StateMachine.SwitchState<PlayerDashState>();
        }
    }

    protected override void EnterCurrentState()
    {
        base.EnterCurrentState();
        _playerNode.AnimationPlayer.Play(AnimationConsts.IDLE);
    }
}
