using DungeonRPG.Scripts.Helper;
using Godot;
using System;

public partial class EnemyChaseState : EnemyStateMachine
{
    protected override void EnterCurrentState()
    {
        _enemyNode.AnimationPlayer.Play(EnemyAnimationConstants.MOVE);
        GD.Print("Chase");
    }
}
