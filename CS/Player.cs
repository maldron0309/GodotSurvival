using Godot;
using System;

public partial class Player : Info
{
	public override void _Ready()
	{

	}

	public override void _PhysicsProcess(double delta)
	{
		Move();
		MoveAndSlide();
	}

	/// <summary>
	/// Player Move 
	/// </summary>
	private void Move()
	{
		Vector2 dir = Input.GetVector("Left", "Right", "Up", "Down");
		Velocity = dir * speed;

		Node happyBoo = GetNode("HappyBoo");

		if (Velocity.Length() > 0)
		{
			happyBoo.Call("play_walk_animation");
		}else{
			happyBoo.Call("play_idle_animation");
		}
	}
}
