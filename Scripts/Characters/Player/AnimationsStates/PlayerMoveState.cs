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


    public override void _Notification(int what)
    {
        base._Notification(what);

        if (what == 5001)
        {
            _playerNode.AnimationPlayer.Play(AnimationConsts.IDLE);
        }
    }
}
