using DungeonRPG.Scripts.Helper;
using Godot;

public abstract partial class PlayerState : CharacterState
{
    public override void _Ready()
    {
        base._Ready();

        _playerNode = GetOwner<Player>();
    }
}
