using DungeonRPG.Scripts.Helper;
using Godot;
using System;

public partial class EnemyIdleState : EnemyStateMachine
{
    protected override void EnterCurrentState()
    {
        _enemyNode.AnimationPlayer.Play(EnemyAnimationConstants.IDLE);
    }
}
