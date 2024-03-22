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


    public override void _Input(InputEvent @event)
    {
        // // Play idle animation when the player release the keys
        // // else play Move animation
        // if (_inputVector.Equals(Vector2.Zero))
        // {
        //     _animationPlayer.Play(AnimationConsts.IDLE);
        // }
        // else
        // {
        //     _animationPlayer.Play(AnimationConsts.MOVE);
        // }
    }
}
