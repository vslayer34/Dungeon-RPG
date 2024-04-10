using DungeonRPG.Scripts.Helper;
using Godot;

public abstract partial class PlayerState : CharacterState
{
    protected Player _playerNode;

    public override void _Ready()
    {
        base._Ready();

        _playerNode = _characterNode as Player;
    }
}
