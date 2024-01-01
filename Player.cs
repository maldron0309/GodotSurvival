using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export] float speed = 300f;

	public override void _PhysicsProcess(double delta)
	{
		LookAt(GetGlobalMousePosition());

		Vector2 moveInput = Input.GetVector("Left","Right","Up","Down");
		
		Velocity = moveInput * speed;

		MoveAndSlide();
	}
}
