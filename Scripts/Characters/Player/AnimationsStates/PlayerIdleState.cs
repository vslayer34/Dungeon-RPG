using DungeonRPG.Scripts.Helper;
using Godot;
using System;

public partial class PlayerIdleState : Node
{
    private Player _playerNode;

    public override void _Ready()
    {
        _playerNode = GetOwner<Player>();
        _playerNode.AnimationPlayer.Play(AnimationConsts.IDLE);
    }
}
