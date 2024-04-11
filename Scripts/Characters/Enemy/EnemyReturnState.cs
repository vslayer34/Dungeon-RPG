using DungeonRPG.Scripts.Helper;
using Godot;
using System;

public partial class EnemyReturnState : EnemyStateMachine
{
    private Vector3 _destination;

    public override void _Ready()
    {
        base._Ready();

        _destination = _enemyNode.PathNode.Curve.GetPointPosition(0);    
    }


    protected override void EnterCurrentState()
    {
        _enemyNode.AnimationPlayer.Play(EnemyAnimationConstants.MOVE);
        _enemyNode.Position = _destination;
    }
}
