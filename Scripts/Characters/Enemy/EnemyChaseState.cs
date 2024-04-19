using DungeonRPG.Scripts.Helper;
using Godot;
using System;
using System.Linq;

public partial class EnemyChaseState : EnemyStateMachine
{
    private CharacterBody3D _targetPlayer;


    protected override void EnterCurrentState()
    {
        _enemyNode.AnimationPlayer.Play(EnemyAnimationConstants.MOVE);
        _targetPlayer = _enemyNode.DetectionArea.GetOverlappingBodies().First() as CharacterBody3D;
    }


    public override void _PhysicsProcess(double delta)
    {
        _destination = _targetPlayer.GlobalPosition;
        _enemyNode.NavAgent.TargetPosition = _destination;

        MoveToDestination();
    }
}
