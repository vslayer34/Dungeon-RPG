using Godot;
using System;

public partial class EnemyStateMachine : CharacterState
{
    protected EnemyKnight _enemyNode;

    public override void _Ready()
    {
        base._Ready();

        _enemyNode = _characterNode as EnemyKnight;
    }
}
