using Godot;
using System;
using System.ComponentModel.DataAnnotations;

public partial class Bullet : Area2D
{
    
	private float travelledDistance = 0;
    private	const float RANGE = 1200;
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

}
