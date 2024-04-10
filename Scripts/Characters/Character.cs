using Godot;

public abstract partial class Character : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export]
    protected AnimationPlayer _animationPlayer;

    [Export]
    protected Sprite3D _sprite3D;

    [Export]
    public StateMachine StateMachine { get; protected set; }

    [Export]
    protected Timer _dashTimer;
}