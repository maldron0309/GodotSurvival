using Godot;
using System;

public interface IDamageable
{
    void TakeDamage();
}


public partial class Damageable : Area2D, IDamageable
{
    public void TakeDamage()
    {
        GD.Print("Damage taken");
    }
}

public partial class Bullet : Area2D
{

    private float travelledDistance = 0;
    private const float RANGE = 1200;
    private const float SPEED = 1000;

    public override void _Ready()
    {
    }


    public override void _PhysicsProcess(double delta)
    {

        var dir = Vector2.Right.Rotated(Rotation);
        Position += dir * SPEED * (float)delta;

        travelledDistance += SPEED * (float)delta;

        if (travelledDistance > RANGE)
        {
            QueueFree();
        }
    }

    public void OnBodyentered(Node body)
    {
        QueueFree();

        if (body.HasMethod("TakeDamage"))
        {
            body.Call("TakeDamage");
        }
    }
}