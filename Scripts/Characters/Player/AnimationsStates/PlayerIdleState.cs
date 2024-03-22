using DungeonRPG.Scripts.Helper;
using Godot;
using System;

public partial class PlayerIdleState : Node
{
    private Player _playerNode;
    

    public override void _Ready()
    {
        _playerNode = GetOwner<Player>();
    }


    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        
        // Change the state to move state when movment input is pressed
        if (_playerNode.InputVector != Vector2.Zero)
        {
            _playerNode.StateMachine.SwitchState<PlayerMoveState>();
        }
    }


    public override void _Notification(int what)
    {
        base._Notification(what);

        // Listen to any change in the current state
        if (what == 5001)
        {
            _playerNode.AnimationPlayer.Play(AnimationConsts.IDLE);
        }
    }
}
