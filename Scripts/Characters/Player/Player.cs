using Godot;
using System;

public partial class Player : CharacterBody3D
{
    private float _speed = 5.0f;
    private Vector2 _inputVector = Vector2.Zero;
    private Vector3 _movmentDirection = Vector3.Zero;
    

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        MovePlayer();
    }


    public override void _Input(InputEvent @event)
    {
        base._Input(@event);

        _inputVector = Input.GetVector(
            negativeX: "MoveLeft",
            positiveX: "MoveRight",
            negativeY: "MoveDown",
            positiveY: "MoveUp"
        );    
    }


    /// <summary>
    /// Apply the movment direction and move the player accordingly
    /// </summary>
    private void MovePlayer()
    {
        _movmentDirection = new Vector3(_inputVector.X, 0.0f, -1 * _inputVector.Y);
        Velocity = _movmentDirection * _speed;

        MoveAndSlide();
    }
}
