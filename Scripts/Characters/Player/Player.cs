using Godot;
using System;
using DungeonRPG.Scripts.Helper;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export]
    private AnimationPlayer _animationPlayer;

    [Export]
    private Sprite3D _sprite3D;

    //----------------------------------------------------------------------------------------

    private float _speed = 5.0f;
    private Vector2 _inputVector = Vector2.Zero;
    private Vector3 _movmentDirection = Vector3.Zero;


    //-----------------------------------------------------------------------------------------

    public override void _Ready()
    {
        // Play idle animation on start
        _animationPlayer.Play(AnimationConsts.IDLE);
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        MovePlayer();
    }


    public override void _Input(InputEvent @event)
    {
        _inputVector = Input.GetVector(
            negativeX: InputConsts.MOVE_LEFT,
            positiveX: InputConsts.MOVE_RIGHT,
            negativeY: InputConsts.MOVE_DOWN,
            positiveY: InputConsts.MOVE_UP
        );


        // Play idle animation when the player release the keys
        // else play Move animation
        if (_inputVector.Equals(Vector2.Zero))
        {
            _animationPlayer.Play(AnimationConsts.IDLE);
        }
        else
        {
            _animationPlayer.Play(AnimationConsts.MOVE);
        }
    }


    /// <summary>
    /// Apply the movment direction and move the player accordingly
    /// </summary>
    private void MovePlayer()
    {
        _movmentDirection = new Vector3(_inputVector.X, 0.0f, -1 * _inputVector.Y);
        Velocity = _movmentDirection * _speed;

        MoveAndSlide();
        Flip();
    }



    /// <summary>
    /// Flip the player sprite according to the moving direction
    /// </summary>
    private void Flip()
    {
        if (Velocity.X == 0)
        {
            return;
        }
        
        _sprite3D.FlipH = Velocity.X < 0;
    }
}
